using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOperations : MonoBehaviour
{
    GameObject selectedDisk = null; //selector to keep hold of a single disc temporarily
    public GameObject Apos, Bpos, Cpos; // to retreive positions for instantiating disks while transferring
    public GameObject[] disks; // An array of all available disks

    // stacks for the towers
    public Stack<GameObject> stackA = new Stack<GameObject>();
    public Stack<GameObject> stackB = new Stack<GameObject>();
    public Stack<GameObject> stackC = new Stack<GameObject>();

    bool flagA, flagB, flagC; // to keep track of from which tower disk is selected and to which tower it is transferred

    public UIManager uiManager; // instance for UIManager script 

    void Start()
    {
        // push all the disks to stackA initially
        foreach (var g in disks)
        {
            stackA.Push(g);
        }
    }

    void Update()
    {
        // if all the disks are transferred to stackC then GameOver
        if (stackC.Count == 6)
        {
            Debug.Log("GameOver");
            uiManager.GameOver();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

            // check if the hit object is disk and the selector is null
            if (Physics.Raycast(rayCast, out raycastHit) && raycastHit.collider.CompareTag("Disk") && selectedDisk == null)
            {
                selectedDisk = raycastHit.collider.gameObject; // if the hit object is disk then assign that disk to selector

                // check if the stackA is not empty and selected disc is at the top of the stack
                if (flagA == false && stackA.Count != 0 && selectedDisk == stackA.Peek())
                {
                    flagA = true;
                    stackA.Pop();
                    return;
                }

                // check if the stackB is not empty and selected disc is at the top of the stack
                if (flagB == false && stackB.Count != 0 && selectedDisk == stackB.Peek())
                {
                    flagB = true;
                    stackB.Pop();
                    return;
                }

                // check if the stackC is not empty and selected disc is at the top of the stack
                if (flagC == false && stackC.Count != 0 && selectedDisk == stackC.Peek())
                {
                    flagC = true;
                    stackC.Pop();
                    return;
                }

                // if the selected disc is not at the top of any of the stack then it's an invalid move
                selectedDisk = null;
                StartCoroutine(uiManager.InvalidMoves());
                Debug.Log("Invalid move");
            }

            // check if the hit object is tower A and the selector is not equal to null
            if (Physics.Raycast(rayCast, out raycastHit) && selectedDisk!=null && raycastHit.collider.CompareTag("A"))
            {
                // if the larger disc is placed at the top of the smaller one => invalid move
                if (stackA.Count != 0 && (int.Parse(selectedDisk.name) < int.Parse(stackA.Peek().name)))
                {
                    Debug.Log("Invalid move");
                    flags(selectedDisk); // return the disc from where it is popped from
                    selectedDisk = null;
                    StartCoroutine(uiManager.InvalidMoves());
                    return;
                }

                // transfer the disc from X to A
                selectedDisk.transform.position = Apos.transform.position;
                stackA.Push(selectedDisk);
                MakeFalse();
                selectedDisk = null;
                UIManager.moves++; // incerement move
                Debug.Log("Done");
            }

            // check if the hit object is tower B and the selector is not equal to null
            if (Physics.Raycast(rayCast, out raycastHit) && selectedDisk != null && raycastHit.collider.CompareTag("B"))
            {
                // if the larger disc is placed at the top of the smaller one => invalid move
                if (stackB.Count != 0 && (int.Parse(selectedDisk.name) < int.Parse(stackB.Peek().name)))
                {
                    Debug.Log("Invalid move");
                    flags(selectedDisk); // return the disc from where it is popped from
                    selectedDisk = null;
                    StartCoroutine(uiManager.InvalidMoves());
                    return;
                }

                // transfer the disc from X to B
                selectedDisk.transform.position = Bpos.transform.position;
                stackB.Push(selectedDisk);
                MakeFalse();
                selectedDisk = null;
                UIManager.moves++; // incerement move
                Debug.Log("Done");
            }

            // check if the hit object is tower C and the selector is not equal to null
            if (Physics.Raycast(rayCast, out raycastHit) && selectedDisk != null && raycastHit.collider.CompareTag("C"))
            {
                // if the larger disc is placed at the top of the smaller one => invalid move
                if (stackC.Count != 0 && (int.Parse(selectedDisk.name) < int.Parse(stackC.Peek().name)))
                {
                    Debug.Log("Invalid move");
                    flags(selectedDisk); // return the disc from where it is popped from
                    selectedDisk = null;
                    StartCoroutine(uiManager.InvalidMoves());
                    return;
                }

                // transfer the disc from X to C
                selectedDisk.transform.position = Cpos.transform.position;
                stackC.Push(selectedDisk);
                MakeFalse();
                selectedDisk = null;
                UIManager.moves++; // incerement move
                Debug.Log("Done");
            }
        }

    }

    // if any invalid move is made, push the selected disk back to where it was popped from 
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

    // turn all the flags to false once a transfer operation is done
    void MakeFalse()
    {
        flagA = false;
        flagB = false;
        flagC = false;
    }

}
