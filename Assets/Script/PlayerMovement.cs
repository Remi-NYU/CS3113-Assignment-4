using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ControllableMonoBehaviour
{

    public float speed = 3.0f;

    Rigidbody2D _rigidbody;
    Cow captured_cow;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))).normalized;
        _rigidbody.velocity = direction * speed;

        if (Input.GetKey(KeyCode.Space))
        {
            captured_cow.Release();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        if (_rigidbody)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            captured_cow = other.gameObject.GetComponent<Cow>();
            captured_cow.Capture(transform, new Vector3(0, -1f, 0));
        }
    }
}
