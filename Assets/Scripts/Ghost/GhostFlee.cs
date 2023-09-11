using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFlee : GhostBehaviour
{
    private Vector2[] directionHierarchy = new Vector2[4];

    public GameObject pacman;
    // Start is called before the first frame update
    void Start()
    {
        pacman = GetComponent<GhostController>().pacman;
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
            

            if (pacman == null)
            {
                newDirections = node.availableDirections;
                
                if (newDirections.Count > 1)
                {
                    newDirections.Remove(-ghost.direction);
                }
            }
            else 
            {
                Vector2 pacmanVec = new Vector2(pacman.transform.position.x - this.transform.position.x, pacman.transform.position.y - this.transform.position.y);
               
                if (Mathf.Abs(pacmanVec.x) > Mathf.Abs(pacmanVec.y))
                {
                    if (pacmanVec.x < 0)
                    {
                        directionHierarchy[3] = Vector2.left;
                        directionHierarchy[0] = Vector2.right;
                    }
                    else
                    {
                        directionHierarchy[3] = Vector2.right;
                        directionHierarchy[0] = Vector2.left;
                    }

                    if (pacmanVec.y < 0)
                    {
                        directionHierarchy[2] = Vector2.down;
                        directionHierarchy[1] = Vector2.up;
                    }
                    else
                    {
                        directionHierarchy[2] = Vector2.up;
                        directionHierarchy[1] = Vector2.down; 
                    }
                }

                else
                {
                    if (pacmanVec.x < 0)
                    {
                        directionHierarchy[2] = Vector2.left;
                        directionHierarchy[1] = Vector2.right;
                    }
                    else
                    {
                        directionHierarchy[2] = Vector2.right;
                        directionHierarchy[1] = Vector2.left;
                    }

                    if (pacmanVec.y < 0)
                    {
                        directionHierarchy[3] = Vector2.down;
                        directionHierarchy[0] = Vector2.up;
                    }
                    else
                    {
                        directionHierarchy[3] = Vector2.up;
                        directionHierarchy[0] = Vector2.down; 
                    }
                }


                if (node.availableDirections.Contains(directionHierarchy[0]))
                {
                    newDirections = new List<Vector2>();
                    newDirections.Add(directionHierarchy[0]);
                }
                else if (node.availableDirections.Contains(directionHierarchy[1]))
                {
                    newDirections = new List<Vector2>();
                    newDirections.Add(directionHierarchy[1]);                    
                }
                else if (node.availableDirections.Contains(directionHierarchy[2]))
                {
                    newDirections = new List<Vector2>();
                    newDirections.Add(directionHierarchy[2]);                    
                }
                else if (node.availableDirections.Contains(directionHierarchy[3]))
                {
                    newDirections = new List<Vector2>();
                    newDirections.Add(directionHierarchy[3]);                    
                }
            }
            
            StartCoroutine(ChangeDirection());
            
        }
    }
    public void SetPacMan(GameObject pacman)
    {
        this.pacman = pacman;
    }
}
