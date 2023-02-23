using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int health = 1;
    public int enenmyType = 1;
    public GameObject deathAnimation;
    public GameObject speedUp;
    
    Rigidbody2D _rigidbody2D;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    
    private void OnTriggerEnter2D(Collider2D other){
        float prob = Random.Range(1,100);
        if (other.CompareTag("Projectile")){
            health -= 1;
            if (health <= 0){
                Instantiate(deathAnimation, transform.position, Quaternion.identity);
                if (enenmyType == 1){
                    GetComponent<Enemy1V2>().releaseCow();
                }
                else if (enenmyType == 2){
                    GetComponent<Enemy2V2>().releaseCow();
                }
                else if (enenmyType == 3){
                    GetComponent<Enemy3V2>().releaseCow();
                }
                else{
                    GetComponent<Enemy4V2>().releaseCow();
                }
                Instantiate(deathAnimation, transform.position, Quaternion.identity);
                if (prob < 20){
                    Instantiate(speedUp, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            
        }
        else if (other.CompareTag("Kill Zone")){
            Destroy(gameObject);
        }

    }
}
