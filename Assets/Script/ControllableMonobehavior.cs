using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllableMonoBehaviour : MonoBehaviour
{
    public virtual void Activate()
    {
        enabled = true;
    }

    public virtual void Deactivate()
    {
        enabled = false;
    }
}
