using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool isInside;
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections;
    public Vector2 pacmanDirection;
    public Vector2 pacmanDirectionEnter;

    // Start is called before the first frame update
    void Start()
    {
        availableDirections = new List<Vector2>();
        if (isInside)
        {
            availableDirections.Add(Vector2.up);
        }
        else
        {
            CheckAvailableDirection(Vector2.up);
            CheckAvailableDirection(Vector2.down);
            CheckAvailableDirection(Vector2.left);
            CheckAvailableDirection(Vector2.right);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckAvailableDirection(Vector2 direction)
    {
       RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0f, direction, 1f, obstacleLayer);
        Debug.DrawRay(transform.position, direction, Color.red, 100.0f);
        if (hit.collider == null)
        {
            availableDirections.Add(direction);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PacMan pacman = other.GetComponent<PacMan>();
        if (pacman != null)
        {
            pacmanDirectionEnter = pacman.direction;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PacMan pacman = other.GetComponent<PacMan>();
        if (pacman != null)
        {
            pacmanDirection = pacman.direction;
        }
    }
}
