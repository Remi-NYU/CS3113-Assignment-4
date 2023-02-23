using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CowCounter : MonoBehaviour
{
    int cow_count = 0;
    public UIBarCowCount cow_counter_ui;
    float timer = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            cow_count++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            cow_count--;
        }
    }

    void Update()
    {
        cow_counter_ui.SetCowCount(cow_count);

        if (cow_count == 0)
        {
            timer += Time.deltaTime;

            if (timer >= 3)
            {
                SceneManager.LoadScene("Lose Screen");
            }
        }
    }
}
