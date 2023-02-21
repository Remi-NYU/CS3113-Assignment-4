using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3V2 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

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
        if (transform.position.y <= lowerBound){
            landed = true;
        }
        if (!carryingCow){
            if (transform.position.y >= lowerBound && !landed){
                _rigidbody2D.velocity = new Vector2(0, -1f);
            }
            else if (isLeft){
                _rigidbody2D.velocity = new Vector2(0, 1f);

            }
            else{
                _rigidbody2D.velocity = new Vector2(-1f, 0);
            }
        }
        else {
            if (isLeft){
                _rigidbody2D.AddForce(new Vector2(-1f, 1f));
            }
            else{
                _rigidbody2D.AddForce(new Vector2(1f, 1f));
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Cow") && !carryingCow){
            if (other.GetComponent<Cow>().IsCaptured() == false){
                other.GetComponent<Cow>().Capture(transform, new Vector3(0,0,0));
                carryingCow = true;
                chosenCow = other.GetComponent<Cow>();
                isLeft = (transform.position.y < 20);
            }
            
        }

    }

    public void releaseCow(){
        chosenCow.Release();
    }
}
