using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class AnimatedPacMan : MonoBehaviour
{

    public SpriteRenderer spriteRenderer { get; private set;}
    public Sprite[] sprites;
    public float time = 0.3f;
    public int frame {get; private set;}


    private void Awake(){
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        InvokeRepeating(nameof(Animate), this.time, this.time);
    }

    private void Animate(){
        if (!this.spriteRenderer.enabled){
            return;
        }

        this.frame ++;
        if (this.frame >= this.sprites.Length){
            this.frame = 0;
        }
        if (this.frame >= 0 && this.frame < this.sprites.Length){
            this.spriteRenderer.sprite = this.sprites[this.frame];
        }
    }
}
