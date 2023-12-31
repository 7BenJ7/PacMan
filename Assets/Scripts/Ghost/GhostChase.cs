using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : GhostBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   

        if (!enabled) return;
        Node node = other.GetComponent<Node>();
        if (node != null)
        {

            if (node.pacmanDirection == Vector2.zero)
            {
                newDirections = node.availableDirections;
                if (newDirections.Count > 1)
                {
                    newDirections.Remove(-ghost.direction);
                }
            }
            else 
            {
                newDirections = new List<Vector2>();
                newDirections.Add(node.pacmanDirection);
                node.pacmanDirection = Vector2.zero;
            }
            
            StartCoroutine(ChangeDirection());
            
        }
    }

}