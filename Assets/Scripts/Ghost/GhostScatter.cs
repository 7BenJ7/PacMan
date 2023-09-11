using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScatter : GhostBehaviour
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
            newDirections = node.availableDirections;
            if (newDirections.Count > 1)
            {
                newDirections.Remove(-ghost.direction);
            }
            
            StartCoroutine(ChangeDirection());
            
        }
    }


    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(0.14f);
        ghost.SetDirection(newDirections[Random.Range(0, newDirections.Count)]); 
    }
}
