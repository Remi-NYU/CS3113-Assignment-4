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
    private Cow[] cows;
    private bool carryingCow = false;
    private Cow chosenCow;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // Get all cows
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Cow");
        for (int i = 0; i < temp.Length; i++){
            cows[i] = temp[i].GetComponent<Cow>();
        }
        // choose one to target
        chosenCow = cows[Random.Range(0, cows.Length)];
        while (chosenCow.IsCaptured()){
            chosenCow = cows[Random.Range(0, cows.Length)];
        }
        stoppingPointY = transform.position.y - 2;
        print(chosenCow.transform.position);
    }


    void Update()
    {
        //initial movement
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
        // look for cow
        else if(!carryingCow){
            while (chosenCow.IsCaptured()){
            chosenCow = cows[Random.Range(0, cows.Length)];
            }
            transform.position = Vector2.MoveTowards(transform.position, chosenCow.transform.position, 0.001f);
        }
        // leave
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
        if (other == chosenCow){
            chosenCow.Capture(transform, new Vector3(0,0,0));
            carryingCow = true;
        }

    }

    public void releaseCow(){
        chosenCow.Release();
    }

}

 
