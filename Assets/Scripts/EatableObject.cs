using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableObject : MonoBehaviour
{
    [SerializeField] 
    private int points;

    [SerializeField] 
    private bool isGomme = false;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerManager pacman))
        {
            GameManager.Instance.ScoreUp(points);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (isGomme)
        {
            foreach(GhostController fantome in GameManager.Instance.fantomes)
            {
                fantome.GetComponent<GhostEat>().IsDamageable();
            }
        }
    }
}
