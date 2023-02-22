using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : ControllableMonoBehaviour
{
    public GameObject projectile_prefab;

    public float spawn_distance = 1;
    public float spawn_cooldown;

    public int projectile_speed = 20;

    float time_since_shot = 999999.0f;

    // public AudioClip shootSnd;
    // AudioSource audio;

    void FixedUpdate()
    {
        time_since_shot += Time.deltaTime;
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space) && time_since_shot >= spawn_cooldown)
        {
            time_since_shot = 0.0f;
            GameObject projectile = Instantiate(projectile_prefab) as GameObject;
            projectile.transform.position = transform.position + new Vector3(0, spawn_distance, 0);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectile_speed);
        }
    }
}
