using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public OptionGeneric[] option_scripts;

    SpriteRenderer[] options;
    int selected = 0;
    int total_options = 0;
    AudioSource audio_source;

    void Start()
    {
        options = transform.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer option in options)
        {
            option.enabled = false;
            total_options++;
        }
        options[0].enabled = true;
        audio_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeSelected(selected, selected + 1 == total_options ? 0 : selected + 1);
            audio_source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeSelected(selected, selected - 1 == -1 ? total_options - 1 : selected - 1);
            audio_source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Select();
        }
    }

    void ChangeSelected(int old_sel, int new_sel)
    {
        selected = new_sel;
        options[old_sel].enabled = false;
        options[new_sel].enabled = true;
    }

    void Select()
    {
        option_scripts[selected].OnPress();
    }
}
