using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : OptionGeneric
{
    bool is_paused = false;
    Canvas text_canvas;
    GameObject menu;
    SpriteRenderer black_background;
    AudioSource audio_source;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();

        text_canvas = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<Canvas>();
        menu = text_canvas.transform.GetChild(0).gameObject;
        black_background = text_canvas.transform.GetChild(1).GetComponent<SpriteRenderer>();

        text_canvas.enabled = false;
        black_background.enabled = false;
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            is_paused = !is_paused;
            if (is_paused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    void Pause()
    {
        is_paused = true;
        Time.timeScale = 0;

        text_canvas.enabled = true;
        black_background.enabled = true;
        menu.SetActive(true);

        audio_source.Play();
    }

    void Unpause()
    {
        is_paused = false;
        Time.timeScale = 1;

        text_canvas.enabled = false;
        black_background.enabled = false;
        menu.SetActive(false);

        audio_source.Play();
    }

    public override void OnPress()
    {
        Unpause();
    }

}
