using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class AnimatedPacMan : MonoBehaviour
{

    public SpriteRenderer spriteRenderer { get; private set;}
    public Sprite[] sprites;
    public float time = 0.3f;
    public bool isDead = false;
    public int frame {get; private set;}


    private void Awake(){
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        InvokeRepeating(nameof(Animate), this.time, this.time);
    }

    private void Animate(){
        if (!isDead)
        {
            if (!this.spriteRenderer.enabled)
            {
                return;
            }

            this.frame++;
            if (this.frame >= 3)
            {
                this.frame = 0;
            }

            if (this.frame >= 0 && this.frame < 3)
            {
                this.spriteRenderer.sprite = this.sprites[this.frame];
            }
        }
        else
        {
            if (!this.spriteRenderer.enabled)
            {
                return;
            }

            if (this.frame == 13)
            {
                Destroy(this.transform.parent.gameObject);
            }

            this.frame++;
            if (this.frame < 3)
            {
                this.frame = 3;
            };
            this.spriteRenderer.sprite = this.sprites[this.frame];
            
        }
    }
    
    
}
