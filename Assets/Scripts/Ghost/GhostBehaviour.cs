using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GhostBehaviour : MonoBehaviour
{
    public GhostController ghost;
    public float duration;

    private void Awake()
    {
        ghost = GetComponent<GhostController>();
    }

    public void Enable()
    {
        Enable(duration);
    }

    public virtual void Enable(float duration)
    {
        enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        enabled = false;

        CancelInvoke();
    }

}