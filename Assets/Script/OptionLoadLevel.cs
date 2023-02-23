using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionLoadLevel : OptionGeneric
{
    public string level_name;

    public override void OnPress()
    {
        SceneManager.LoadScene(level_name);
    }
}
