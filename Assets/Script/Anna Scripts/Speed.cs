using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

    public int speed = 8;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, -(speed*10)));
        
    }
    
    private void OnTriggerEnter2D(Collider2D other){
    //    if (other.CompareTag("Player")){
    //        Destroy(gameObject);
    //    }
        if (other.CompareTag("Kill Zone")){
            Destroy(gameObject);
        }
    }
}
