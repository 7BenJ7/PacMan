using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections;

    // Start is called before the first frame update
    void Start()
    {
        availableDirections = new List<Vector2>();
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.0f, obstacleLayer);
        if (hit.collider == null)
        {
            availableDirections.Add(direction);
            Debug.Log("Clear");
        }
        else{
            Debug.Log("Obstacle");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Node");
    }
}
