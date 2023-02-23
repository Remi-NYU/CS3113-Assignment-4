using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float total_time = 60;
    public string next_level;

    float time_left;
    Transform mask_transform;

    void Start()
    {
        time_left = total_time;
        mask_transform = transform.GetChild(0).GetChild(0);
    }

    void FixedUpdate()
    {
        time_left -= Time.deltaTime;

        UpdateTimeDisplay();

        if (time_left > 0)
        {
            return;
        }
        time_left = 0;

        Win();
    }

    void UpdateTimeDisplay()
    {
        mask_transform.localScale = new Vector3(2 * (time_left / total_time), 1, 1);
    }

    void Win()
    {
        SceneManager.LoadScene(next_level);
    }
}
