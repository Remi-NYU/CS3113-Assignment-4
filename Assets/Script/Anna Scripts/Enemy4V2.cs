using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4V2 : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    private List<Cow> cows;
    private bool carryingCow = false;
    private Cow chosenCow;

    private bool isLeft;

    void Start()
    {
         _rigidbody2D = GetComponent<Rigidbody2D>();
         isLeft = transform.position.x < 5;
        
    }
    
    void FixedUpdate()
    {
        if (!carryingCow){
            if (isLeft){
                _rigidbody2D.velocity = new Vector2(1f, 0);
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
                isLeft = (transform.position.y < 50);
            }
            
        }

    }

    public void releaseCow(){
        if(carryingCow){
            chosenCow.Release();
        }
        
    }
}
