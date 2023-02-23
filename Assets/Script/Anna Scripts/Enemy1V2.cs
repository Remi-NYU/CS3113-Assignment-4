using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1V2 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    // Pause time when initially entering
    public float initialDelay = 1f;
    private float stoppingPointY = 3f;
    private bool stopped = false;

    private float lowerBound = -1.75f;
    private bool isLeft;

    private bool carryingCow = false;
    private Cow chosenCow;

    private bool landed = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        isLeft = (transform.position.x < 20);

    }


    void FixedUpdate()
    {
        if (transform.position.y <= lowerBound)
        {
            landed = true;
        }
        if (!stopped)
        {
            if (transform.position.y <= stoppingPointY)
            {
                _rigidbody2D.velocity = new Vector2(0, 0);
                initialDelay -= Time.deltaTime;
                if (initialDelay <= 0)
                {
                    stopped = true;

                }
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(0, -1f);
            }
            isLeft = (transform.position.x < 20);
        }
        else if (!carryingCow)
        {
            if (transform.position.y > lowerBound && !landed)
            {
                if (isLeft)
                {
                    _rigidbody2D.velocity = new Vector2(0.3f, -1f);

                }
                else
                {
                    _rigidbody2D.velocity = new Vector2(-0.3f, -1f);
                }
            }
            else
            {
                if (isLeft)
                {
                    _rigidbody2D.velocity = new Vector2(0.5f, 0);

                }
                else
                {
                    _rigidbody2D.velocity = new Vector2(-0.5f, 0);
                }
            }
        }
        else
        {
            if (isLeft)
            {
                _rigidbody2D.AddForce(new Vector2(-1f, 1f));
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(1f, 1f));
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cow") && !carryingCow)
        {
            if (other.GetComponent<Cow>().IsCaptured() == false)
            {
                other.GetComponent<Cow>().Capture(transform, new Vector3(0, 0, 0));
                carryingCow = true;
                chosenCow = other.GetComponent<Cow>();
                isLeft = (transform.position.y < 20);
            }

        }

    }

    public void releaseCow()
    {
        if (carryingCow)
        {
            chosenCow.Release();
        }

    }
}
