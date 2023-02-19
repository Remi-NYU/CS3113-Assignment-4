using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBarItem : MonoBehaviour
{

    // Item meter
    Transform _item_meter_transform;
    float min_scale = 1;
    float max_scale = 9;
    public float item_bar_percentage = 0;

    void Start()
    {
        _item_meter_transform = transform.GetChild(0).GetChild(0);
    }

    void Update()
    {
        float new_scale = (item_bar_percentage / 100f) * (max_scale - min_scale) + min_scale;
        _item_meter_transform.localScale = new Vector3(1, new_scale, 0);
    }

    public void SetItemBarPercentage(float new_percentage)
    {
        item_bar_percentage = new_percentage;
    }

    public float GetItemBarPercentage()
    {
        return item_bar_percentage;
    }
}
