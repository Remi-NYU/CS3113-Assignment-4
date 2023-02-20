using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    private bool carryingCow = false;
    const float TIMER = 1.5f;
    const float TIMEL = 0.5f;

    public float YBound = 0.0f;
    private int status = 0;
    private bool headRight = true;
    private float timeRight = TIMER;
    private float timeLeft = TIMEL;

    private Cow chosenCow;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < YBound && status != 2){
            status = 1;
        }
        if (timeRight > 0){
            headRight = true;
        }
        else if (timeRight <= 0 && timeLeft > 0){
            headRight = false;
        }
        else{
            if(status == 0){
                timeRight = TIMER;
                timeLeft = TIMEL;
            }
            else{
                timeRight = TIMER;
                timeLeft = TIMEL;
            }
            
        }
        if(headRight && status != 1){
            if(status == 0){
                _rigidbody2D.velocity = new Vector2(1, -1);
                timeRight -= Time.deltaTime;
            }
            else if (status == 2){
                _rigidbody2D.velocity = new Vector2(1, 1);
                timeRight -= Time.deltaTime;
            }
        }
        else if (!headRight && status != 1){
            if(status == 0){
                _rigidbody2D.velocity = new Vector2(-1.5f, -1.5f);
                timeLeft -= Time.deltaTime;
            }
            else if (status == 2){
                _rigidbody2D.velocity = new Vector2(-1.5f, 1.5f);
                timeLeft -= Time.deltaTime;
            }
        }
        else{
            _rigidbody2D.velocity = new Vector2(1.2f, 0);
        }

    }
        
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Cow") && !carryingCow){
            if (other.GetComponent<Cow>().IsCaptured() == false){
                other.GetComponent<Cow>().Capture(transform, new Vector3(0,0,0));
                carryingCow = true;
                status = 2;
                chosenCow = other.GetComponent<Cow>();
            }
            
        }

    }

    public void releaseCow(){
        chosenCow.Release();
    }
}
