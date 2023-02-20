using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineEnemy : MonoBehaviour
{
    SpriteRenderer flower;
    Animator flower_animator;
    Quaternion flower_initial_rotation;
    SpriteRenderer[] vine_segments;
    int flower_position = 0;

    void Start()
    {
        flower = transform.GetChild(1).GetComponent<SpriteRenderer>();
        flower_animator = flower.GetComponent<Animator>();
        flower_initial_rotation = flower.transform.rotation;
        vine_segments = transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        UpdateFlower();
        UpdateVines();
    }

    void UpdateFlower()
    {
        flower.transform.position = vine_segments[flower_position].transform.position;
        flower.transform.rotation = flower_initial_rotation;

        if (flower_position % 6 == 1 && flower_position != 1)
        {
            flower.transform.Rotate(new Vector3(0, 0, -90));
        }
        else if (((flower_position - 1) / 6) % 2 == 1)
        {
            flower.transform.Rotate(new Vector3(0, 0, -180));
        }
    }

    void UpdateVines()
    {
        foreach (SpriteRenderer s in vine_segments)
        {
            s.enabled = false;
        }

        for (int i = 0; i < flower_position; i++)
        {
            vine_segments[i].enabled = true;
        }
    }

    public int GetPosition()
    {
        return flower_position;
    }

    public void SetPosition(int new_pos)
    {
        flower_position = new_pos;
        if (flower_position >= vine_segments.Length)
        {
            flower_position = vine_segments.Length - 1;
        }
        if (flower_position < 0)
        {
            flower_position = 0;
        }
    }

    public Transform GetFlowerTransform()
    {
        return flower.transform;
    }

    public void TriggerHurtAnimation()
    {
        flower_animator.SetTrigger("Hurt");
    }
}
