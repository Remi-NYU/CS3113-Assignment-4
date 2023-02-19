using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBarCowCount : MonoBehaviour
{
    TMP_Text _cow_count_text;
    int cow_num = 0;

    void Start()
    {
        _cow_count_text = transform.GetChild(2).GetComponent<TMP_Text>();
    }

    void UpdateCowText()
    {
        if (_cow_count_text)
        {
            _cow_count_text.text = cow_num.ToString();
        }
    }

    public void SetCowCount(int cow_count)
    {
        cow_num = cow_count;
        UpdateCowText();
    }

    public int GetCowCount()
    {
        return cow_num;
    }
}
