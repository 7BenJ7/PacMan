using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public int ghostType;
    public Vector2 direction;
    public float speed;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = direction * speed;
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

}
