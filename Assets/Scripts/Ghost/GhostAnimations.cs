using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostAnimations : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public UnityEngine.U2D.Animation.SpriteResolver spriteResolver;
    public UnityEngine.U2D.Animation.SpriteResolver eyesSpriteResolver;

    public GhostController ghost;

    private bool spriteState;
    private float animationsTimer;
    public float animationsDelay;


    // Start is called before the first frame update
    void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.spriteResolver = GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        this.eyesSpriteResolver = transform.GetChild(0).GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        this.spriteState = true;
        ghost = GetComponent<GhostController>();
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

        UpdateEyes();
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

    void UpdateEyes()
    {
        switch (ghost.direction)
        {
            case var value when value == Vector2.up:
                eyesSpriteResolver.SetCategoryAndLabel("Eyes", "Eyes Up");
                break;
            case var value when value == Vector2.down:
                eyesSpriteResolver.SetCategoryAndLabel("Eyes", "Eyes Down");
                break;
            case var value when value == Vector2.left:
                eyesSpriteResolver.SetCategoryAndLabel("Eyes", "Eyes Left");
                break;
            case var value when value == Vector2.right:
                eyesSpriteResolver.SetCategoryAndLabel("Eyes", "Eyes Right");
                break;
            default:
            break;
        }
    }
    
}
