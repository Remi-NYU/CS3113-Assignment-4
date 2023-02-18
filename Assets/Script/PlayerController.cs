using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool enabled_by_default;
    public ControllableMonoBehaviour[] controlled_scripts;

    void Start()
    {
        if (enabled_by_default)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        foreach (ControllableMonoBehaviour script in controlled_scripts)
        {
            script.Activate();
        }
    }

    public void Deactivate()
    {
        foreach (ControllableMonoBehaviour script in controlled_scripts)
        {
            script.Deactivate();
        }
    }
}
