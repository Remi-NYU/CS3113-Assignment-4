using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ControllableMonoBehaviour
{

    public float speed = 3.0f;

    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;
        _rigidbody.velocity = direction * speed;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        if (_rigidbody)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
