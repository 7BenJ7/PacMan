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
            col.transform.position = newPosition.position;
        }
        else
        {
            if (!ghost.justTeleport)
            {
                col.transform.position = newPosition.position;
                ghost.justTeleport = true;
            }

        }


       
        


    }
}
