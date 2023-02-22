using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPlayerShoot : MonoBehaviour
{
    public GameObject vinePrefab;   // vine projectile
    public Transform spawnPoint;    // where vine will spawn from
    public int vineSpeed = 100; // speed of vine projectile

    // public AudioClip shootSnd;
    // AudioSource audio;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {  
            // when spacebar is pressed, spawn vine projectile up to certain distance and retract

            // audio.PlayOneShot(shootSnd);

            GameObject newVine = Instantiate(vinePrefab, spawnPoint.position, Quaternion.identity); //copies
            newVine.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, vineSpeed));    // move up

            // // IF VINE REACHES Y=0 COME BACK DOWN?
            if(newVine.transform.position.y >= 1f) {
                newVine.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, vineSpeed*-1));
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.CompareTag("Enemy")) {
    //         // IF VINE HITS SOMETHING (COLLIDES), COME BACK DOWN
    //         gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, vineSpeed*-1));
    //     }
    // }
}
