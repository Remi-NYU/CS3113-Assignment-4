using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    private List<Cow> cows;
    private bool carryingCow = false;
    private Cow chosenCow;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // Get all cows
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Cow");
        cows = new List<Cow>();
        for (int i = 0; i < temp.Length; i++){
            Cow tempCow = temp[i].GetComponent<Cow>();
            cows.Add(tempCow);
        }
        // choose one to target
        chosenCow = cows[Random.Range(0, cows.Count)];
        while (chosenCow.IsCaptured()){
            chosenCow = cows[Random.Range(0, cows.Count)];
        }

        
    }

    void Update()
    {
        if(!carryingCow){
            while (chosenCow.IsCaptured()){
            chosenCow = cows[Random.Range(0, cows.Count)];
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
        if (other.CompareTag("Cow")){
            chosenCow.Capture(transform, new Vector3(0,0,0));
            carryingCow = true;
        }

    }

    public void releaseCow(){
        chosenCow.Release();
    }
}
