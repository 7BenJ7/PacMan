using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableObject : MonoBehaviour
{
    [SerializeField] 
    private int points;

    public bool canBeEat = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerManager pacman) && canBeEat)
        {
            GameManager.Instance.ScoreUp(points);
            Destroy(gameObject);
        }
    }
}
