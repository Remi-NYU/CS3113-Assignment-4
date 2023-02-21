using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelatedMovement : MonoBehaviour
{
    public float space_unit = 0.02f;
    public int x_speed = 2;
    public int y_speed = 1;
    public int time_unit = 10;
    int time_accumulator = 0;

    void FixedUpdate()
    {
        time_accumulator += (int)(Time.deltaTime * 1000);
        Vector3 displacement = new Vector3(x_speed, y_speed, 0) * (time_accumulator / time_unit) * space_unit;
        transform.position = transform.position - displacement;
        time_accumulator = time_accumulator % time_unit;
    }
}
