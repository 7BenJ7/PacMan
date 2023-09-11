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
            if (isGomme)
            {
                AudioManager.Instance.PlaySFX("Gomme");
            }
            else
            {
                AudioManager.Instance.PlaySFX("Pastille");
            }
            GameManager.Instance.ScoreUp(points);
            GameManager.Instance.GommeRestante();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (isGomme)
        {
            foreach(GhostController fantome in GameManager.Instance.ghostInstances)
            {
                fantome.GetComponent<GhostEat>().IsDamageable();
            }
        }
    }
}
