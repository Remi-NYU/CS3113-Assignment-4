using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineProjectile : MonoBehaviour
{
    private Vector2 target_up;
    private Vector2 position;

    float time = 1.5f;

    void Start()
    {
        target_up = new Vector2(this.transform.position.x, -0.9f);
        position = gameObject.transform.position;

    }

    void Update()
    {
        StartCoroutine(MoveVine());
    }

    IEnumerator MoveVine()
    {
        
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position= Vector2.Lerp(position, target_up, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        elapsedTime = 0f;

        while (elapsedTime < time)
        {
            transform.position= Vector2.Lerp(target_up, position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
