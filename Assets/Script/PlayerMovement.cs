using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ControllableMonoBehaviour
{

    public float speed = 1.0f;
    public GameObject glowPrefab;   // glow on player

    public Rigidbody2D _rigidbody;



    public AudioClip itemSnd;   // sound when collecting powerup
    AudioSource audio;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))).normalized;
        _rigidbody.velocity = direction * speed;

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            // play sound when collected
            audio.PlayOneShot(itemSnd);

            // glow effect + increase speed
            // // if player collides with power up, increase its speed

            StartCoroutine(PowerUp());  // coroutine that changes speed + glow
            Destroy(other.gameObject);  // destroy item
            
        }
    }

    IEnumerator PowerUp() {
        glowPrefab.GetComponent<Light>().color = new Color(0,255,0);    // change glow to green
        speed = speed * 2f; // speed up
        yield return new WaitForSeconds(5);
        speed = speed / 2f; // revert speed
        glowPrefab.GetComponent<Light>().color = new Color(255,255,255);    // change glow back to white
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
