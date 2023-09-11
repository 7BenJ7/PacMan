using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PacMan : MonoBehaviour
{
    public Rigidbody2D body {get; private set; }


    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask obstacle;
    public Vector2 direction { get; private set; }
    public Vector2 nextDirection{ get; private set; }
    public Vector3 startingPosition{ get; private set; }


    private void Awake(){
        this.body = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        ResetState();
    }

    // Update is called once per frame
    void Update() {

        
        if (this.nextDirection != Vector2.zero){
            SetDirection(this.nextDirection);
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow)){
            this.SetDirection(Vector2.up);
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            this.SetDirection(Vector2.down);
        } else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow)){
            this.SetDirection(Vector2.left);
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            this.SetDirection(Vector2.right);
        }
        float angle = Mathf.Atan2(this.direction.y, this.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward );

    }
    private void FixedUpdate()
    {
        Vector2 position = this.body.position;
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime; 
        this.body.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction){
        if(!Occupied(direction)){
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        } else {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction){
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.0f, this.obstacle);
        return hit.collider != null;

    }

    public void ResetState(){
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        //this.body.isKinetic = false; //GHOSTS
        this.enabled = true;
    }
}
