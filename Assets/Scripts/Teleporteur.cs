using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    [SerializeField]
    private Transform newPosition;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        GhostController ghost = col.gameObject.transform.GetComponent<GhostController>();
        if (ghost == null)
        {
            Debug.Log(col.gameObject.name);
            col.transform.position = newPosition.position;
        }
        else
        {
            if (!ghost.justTeleport)
            {
                Debug.Log(col.gameObject.name);
                col.transform.position = newPosition.position;
                ghost.justTeleport = true;
            }

        }


       
        


    }
}
