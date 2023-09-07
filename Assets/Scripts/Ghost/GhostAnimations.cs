using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostAnimations : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public UnityEngine.U2D.Animation.SpriteResolver spriteResolver;

    private bool spriteState;
    private float animationsTimer;
    public float animationsDelay;


    // Start is called before the first frame update
    void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.spriteResolver = GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        this.spriteState = true;
        animationsTimer = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationsTimer += Time.deltaTime;
        if (animationsTimer >= animationsDelay)
        {
            animationsTimer = 0;
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        if (spriteState)
        {
            spriteResolver.SetCategoryAndLabel("Body", "Body 1");
        }
        else 
        {
            spriteResolver.SetCategoryAndLabel("Body", "Body 2");
        }

        spriteState = !spriteState;
    }
}
