using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCounter : MonoBehaviour
{
    int cow_count = 0;
    UIBarCowCount cow_counter_ui;


    void Start()
    {
        cow_counter_ui = GameObject.FindGameObjectWithTag("UIBar").GetComponent<UIBarCowCount>();
    }

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
    }
}
