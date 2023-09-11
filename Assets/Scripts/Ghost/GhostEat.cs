using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEat : MonoBehaviour
{
    [SerializeField] private int points;
    
    public bool _canBeEat = false;
    private GhostBehaviour ghostBehaviourScript;
    private GhostBehaviour ghostFleeScript;
    private Color _color;
    private bool _canBeEat = false;

    private void Start()
    {
        _color = GetComponentInChildren<SpriteRenderer>().color;
        ghostBehaviourScript = GetComponent<GhostController>().ghostBehaviourScript;
        ghostFleeScript = GetComponent<GhostController>().ghostFleeScript;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerManager pacman) )
        {
            
            if (!_canBeEat)
            {
                pacman.TakeDamage();
            }
            else
            {
                AudioManager.Instance.PlaySFX("Fantome");
                GameManager.Instance.ScoreUp(points);
                GameManager.Instance.fantomes.Remove(GetComponent<GhostController>());
                Destroy(gameObject);
            }
        }
    }

   public void IsDamageable()
   {
       StartCoroutine(EatableGhostCoroutine());
   }

   private IEnumerator EatableGhostCoroutine()
    {
        if (ghostBehaviourScript.enabled)
        {
            ghostBehaviourScript.Disable();
            ghostFleeScript.Enable();
        }

        _canBeEat = true;
        GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(5);
        ghostFleeScript.Disable();
        ghostBehaviourScript.Enable();
        _canBeEat = false;
        GetComponentInChildren<SpriteRenderer>().color = _color;
    }
}
