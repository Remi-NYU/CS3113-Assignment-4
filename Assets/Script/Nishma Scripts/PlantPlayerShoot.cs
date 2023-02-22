using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPlayerShoot : MonoBehaviour
{
    public GameObject vinePrefab;   // vine projectile
    public Transform spawnPoint;    // where vine will spawn from


    // public AudioClip shootSnd;
    // AudioSource audio;

    // Update is called once per frame
    public void Update()
    {

        if(Input.GetButtonDown("Jump")) {  
            Debug.Log("Jump");
            // when spacebar is pressed, spawn vine projectile up to certain distance and retract

            // audio.PlayOneShot(shootSnd);

            GameObject newVine = Instantiate(vinePrefab, spawnPoint.position, Quaternion.identity); //copies
            // Debug.Log("y position: " + newVine.transform.position.y);

            // newVine.GetComponent<Rigidbody2D>().AddForce(Vector2.up * vineSpeed);    // move up
            // StartCoroutine(Down(newVine));
            // newVine.GetComponent<Rigidbody2D>().AddForce(Vector2.down * vineSpeed);

        }

    }

}
