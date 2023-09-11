using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAway : GhostBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;
        Node node = other.GetComponent<Node>();
        if (node != null)
        {
            if (node.pacmanDirectionEnter == Vector2.zero)
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
                newDirections.Add(-node.pacmanDirectionEnter);
                node.pacmanDirectionEnter = Vector2.zero;
            }
            
            StartCoroutine(ChangeDirection());
            
        }
    }


}

