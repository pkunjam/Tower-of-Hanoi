using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    GameObject selectedDisk = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayCast, out raycastHit) && raycastHit.collider.CompareTag("Disk"))
            {
                selectedDisk = raycastHit.collider.gameObject;
            }
        }
        
    }
}
