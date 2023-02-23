using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionQuitGame : OptionGeneric
{
    public override void OnPress()
    {
#if !UNITY_WEBGL
        Application.Quit();
#endif
    }
}
