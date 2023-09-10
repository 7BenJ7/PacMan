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
        Debug.Log(col.gameObject.name);
        col.transform.position = newPosition.position;
    }
}
