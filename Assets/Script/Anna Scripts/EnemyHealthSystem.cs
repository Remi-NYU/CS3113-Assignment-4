using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int health = 3;
    public int enenmyType = 1;

    // visual effects
    // public GameObject explosion;
    // public GameObject damage;

    // Audio
    // public AudioClip enemyDamageSound;
    // public AudioClip enemyDeathSound;
    AudioSource _audioSource;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Bullet")){
            health -= 1;
            
            if (health <= 0){
                //Instantiate(explosion, transform.position, Quaternion.identity);
                if (enenmyType == 1){
                    GetComponent<Enemy1>().releaseCow();
                }
                else if (enenmyType == 2){
                    GetComponent<Enemy2>().releaseCow();
                }
                else if (enenmyType == 3){
                    GetComponent<Enemy3>().releaseCow();
                }
                else{
                    GetComponent<Enemy4>().releaseCow();
                }
                
                Destroy(gameObject);
            }
            else{
                //Instantiate(damage, transform.position, Quaternion.identity);
                //_audioSource.PlayOneShot(enemyDamageSound);
            }
            
        }
        else if (other.CompareTag("Kill Zone")){
            Destroy(gameObject);
        }

    }
}
