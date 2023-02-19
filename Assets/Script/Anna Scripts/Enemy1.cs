using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    // Pause time when initially entering
    public float initialDelay = 2f;
    private float stoppingPointY;
    private bool stopped = false;

    // cow related
    public GameObject[] cows;
    private bool carryingCow = false;
    private GameObject chosenCow;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        cows = GameObject.FindGameObjectsWithTag("Cow");
        chosenCow = cows[Random.Range(0, cows.Length)];
        stoppingPointY = transform.position.y - 2;

    }

    
    void Update()
    {
        if (!stopped){
            if (transform.position.y <= stoppingPointY){
                initialDelay -= Time.deltaTime;
                if (initialDelay <= 0){
                    stopped = true;
                }
                
            }
            else{
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, stoppingPointY), 0.0008f);
            }
        }
        else if(!carryingCow){
            transform.position = Vector2.MoveTowards(transform.position, chosenCow.transform.position, 0.001f);
        }
        else {
            if (transform.position.x < 0){
                _rigidbody2D.AddForce(new Vector2(-0.2f, 0.2f));
            }
            else{
                _rigidbody2D.AddForce(new Vector2(0.2f, 0.2f));
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Cow")){
            // What happens when cows get caught
            carryingCow = true;
        }

    }

}

 
