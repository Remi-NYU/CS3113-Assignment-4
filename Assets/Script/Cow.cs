using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{

    Rigidbody2D _rigidbody;
    // Falling stuff
    public float space_unit = 0.02f;
    public int fall_speed = 1;
    public int time_unit = 10;
    float normal_height;
    int time_accumulator = 0;

    // Walking stuff
    Quaternion initial_rotation;
    float walking_interval = 5;
    float walking_timer = 0;

    // Capture stuff
    bool is_captured = false;
    Transform captor_transform;
    Vector3 captor_offset;

    void Start()
    {
        normal_height = transform.position.y;
        initial_rotation = transform.rotation;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!is_captured)
        {
            Walking();
        }
        else
        {
            Captured();
        }
    }

    void Walking()
    {
        if (transform.position.y > normal_height)
        {
            time_accumulator += (int)(Time.deltaTime * 1000);
            Vector3 displacement = new Vector3(0, fall_speed, 0) * (time_accumulator / time_unit) * space_unit;
            _rigidbody.MovePosition(transform.position - displacement);
            time_accumulator = time_accumulator % time_unit;
        }
        else
        {
            _rigidbody.MovePosition(new Vector3(transform.position.x, normal_height, 0));
        }
        walking_timer += Time.deltaTime;
        if (walking_timer >= walking_interval)
        {
            walking_timer = 0;
            int rng = Random.Range(0, 3);
            transform.rotation = initial_rotation;
            if (rng == 1)
            {
                _rigidbody.MovePosition(transform.position + new Vector3(space_unit * 10, 0, 0));
            }
            else if (rng == 2)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                _rigidbody.MovePosition(transform.position + new Vector3(-space_unit * 10, 0, 0));
            }
        }
    }

    void Captured()
    {
        _rigidbody.MovePosition(captor_transform.position + captor_offset);
    }

    //
    // Summary:
    //     Links the cow to a game object that has captured it
    //
    // Parameters:
    //   captor_transform:
    //     The transform of the game object doing the capturing
    //
    //   offset:
    //     Where to position the cow relative to the captor_transform while it's captured
    public void Capture(Transform captortransform, Vector3 offset)
    {
        is_captured = true;
        captor_transform = captortransform;
        captor_offset = offset;
    }

    public void Release()
    {
        is_captured = false;
    }
}
