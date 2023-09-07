using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public int ghostType;
    public int direction;
    int[] avaibleDirections;
    public float speed;
    Rigidbody2D body;
    //1 = down; 2 = left; 3 = right; 4 = up; 0 = idle;

    int horizontal;
    int vertical;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(direction)
        {
            case 0:
                horizontal = 0;
                vertical = 0;
                break;
            case 1: 
                horizontal = 0;
                vertical = -1;
                break;
            case 2: 
                horizontal = -1;
                vertical = 0;
                break;
            case 3: 
                horizontal = 1;
                vertical = 0;
                break;
            case 4: 
                horizontal = 0;
                vertical = 1;
                break;  
            default:
                break;  

        }

        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void SetDirection(int newDirection)
    {
        direction = newDirection;
    }

}
