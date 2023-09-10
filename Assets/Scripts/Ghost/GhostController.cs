using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{


    public int ghostType;
    public Vector2 direction;
    public float speed;
    Rigidbody2D body;
    public bool justTeleport;
    public float tpCoolDown = 0.25f;
    public float tpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = direction * speed;
        if(justTeleport)
        {
            tpTime += Time.deltaTime;
            if (tpTime > tpCoolDown)
            {
                tpTime = 0;
                justTeleport = false;
            }
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    


    
}
