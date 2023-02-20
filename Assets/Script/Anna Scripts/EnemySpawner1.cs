using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner1 : MonoBehaviour
{
    public GameObject enemy1PreFab;
    public GameObject enemy2PreFab;
    public GameObject enemy3PreFab;
    public GameObject enemy4PreFab;

    public string levelName = "Level 1";


    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        for(int i = 0; i < 10; i++){
            Vector2 spawnPos = new Vector2(Random.Range(-8,8), 5);
            Instantiate(enemy1PreFab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1f);

        }


    }
}
