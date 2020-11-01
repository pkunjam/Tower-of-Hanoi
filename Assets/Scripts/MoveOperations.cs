using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOperations : MonoBehaviour
{
    GameObject selectedDisk = null;
    public GameObject Apos, Bpos, Cpos;
    public GameObject[] disks;
    public Stack<GameObject> stackA = new Stack<GameObject>();
    public Stack<GameObject> stackB = new Stack<GameObject>();
    public Stack<GameObject> stackC = new Stack<GameObject>();
    bool flagA, flagB, flagC;

    void Start()
    {
        foreach (var g in disks)
        {
            stackA.Push(g);
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayCast, out raycastHit) && raycastHit.collider.CompareTag("Disk") && selectedDisk == null)
            {
                selectedDisk = raycastHit.collider.gameObject;

                if (flagA == false && stackA.Count != 0 && selectedDisk == stackA.Peek())
                {
                    flagA = true;
                    stackA.Pop();
                    return;
                }

                if (flagB == false && stackB.Count != 0 && selectedDisk == stackB.Peek())
                {
                    flagB = true;
                    stackB.Pop();
                    return;
                }

                if (flagC == false && stackC.Count != 0 && selectedDisk == stackC.Peek())
                {
                    flagC = true;
                    stackC.Pop();
                    return;
                }

                selectedDisk = null;
                StartCoroutine(UIManager.InvalidMoves());
                Debug.Log("Invalid move");
            }

            if(Physics.Raycast(rayCast, out raycastHit) && selectedDisk!=null && raycastHit.collider.CompareTag("A"))
            {
                if (stackA.Count != 0 && (int.Parse(selectedDisk.name) < int.Parse(stackA.Peek().name)))
                {
                    Debug.Log("Invalid move");
                    flags(selectedDisk);
                    selectedDisk = null;
                    StartCoroutine(UIManager.InvalidMoves());
                    return;
                }

                selectedDisk.transform.position = Apos.transform.position;
                stackA.Push(selectedDisk);
                MakeFalse();
                selectedDisk = null;
                UIManager.moves++;
                Debug.Log("Done");
            }

            if (Physics.Raycast(rayCast, out raycastHit) && selectedDisk != null && raycastHit.collider.CompareTag("B"))
            {
                if (stackB.Count != 0 && (int.Parse(selectedDisk.name) < int.Parse(stackB.Peek().name)))
                {
                    Debug.Log("Invalid move");
                    flags(selectedDisk);
                    selectedDisk = null;
                    StartCoroutine(UIManager.InvalidMoves());
                    return;
                }

                selectedDisk.transform.position = Bpos.transform.position;
                stackB.Push(selectedDisk);
                MakeFalse();
                selectedDisk = null;
                UIManager.moves++;
                Debug.Log("Done");
            }

            if (Physics.Raycast(rayCast, out raycastHit) && selectedDisk != null && raycastHit.collider.CompareTag("C"))
            {
                if (stackC.Count != 0 && (int.Parse(selectedDisk.name) < int.Parse(stackC.Peek().name)))
                {
                    Debug.Log("Invalid move");
                    flags(selectedDisk);
                    selectedDisk = null;
                    StartCoroutine(UIManager.InvalidMoves());
                    return;
                }

                selectedDisk.transform.position = Cpos.transform.position;
                stackC.Push(selectedDisk);
                MakeFalse();
                selectedDisk = null;
                UIManager.moves++;
                Debug.Log("Done");
            }
        }
        
    }

    void flags(GameObject selected)
    {
        if (flagA)
        {
            flagA = false;
            stackA.Push(selected);
            return;
        }

        if (flagB)
        {
            flagB = false;
            stackB.Push(selected);
            return;
        }

        if (flagC)
        {
            flagC = false;
            stackC.Push(selected);
            return;
        }
    }

    void MakeFalse()
    {
        flagA = false;
        flagB = false;
        flagC = false;
    }

}
