using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHomeBehaviour : GhostBehaviour
{

    public GameObject inside;
    private Rigidbody2D rigidbody;
    GhostBehaviour nextBehaviour;
    GhostBehaviour fleeBehaviour;

    public float waitingTime;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        nextBehaviour = GetComponent<GhostController>().ghostBehaviourScript;
        fleeBehaviour = GetComponent<GhostController>().ghostFleeScript;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            rigidbody.MovePosition(new Vector2(inside.transform.position.x, inside.transform.position.y));
            timer = 0;
            Disable();
            if (GetComponent<GhostEat>()._canBeEat)
            {
                fleeBehaviour.Enable();
            }
            else
            {
                nextBehaviour.Enable();
            }
        }
    }
}
