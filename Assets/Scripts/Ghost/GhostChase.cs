using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : GhostBehaviour
{
    List<Vector2> newDirections;
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

        Node node = other.GetComponent<Node>();
        if (node != null)
        {

            if (node.pacamanDirection == null)
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
                newDirections.Add(node.pacamanDirection);
            }
            
            StartCoroutine(ChangeDirection());
            
        }
    }


    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(0.37f);
        ghost.SetDirection(newDirections[Random.Range(0, newDirections.Count)]); 
    }
}