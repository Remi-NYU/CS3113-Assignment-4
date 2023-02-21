using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner1 : MonoBehaviour
{
    public GameObject enemy1PreFab;
    public GameObject enemy2PreFab;
    public GameObject enemy3PreFab;
    public GameObject enemy4PreFab;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        for(int i = 0; i < 3; i++){
            Vector2 spawnPos = new Vector2(Random.Range(18,23), 4.5f);
            Instantiate(enemy1PreFab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(2f);

        }

        yield return new WaitForSeconds(3f);

        for(int i = 18; i < 23; i += 2){
            Vector2 spawnPos = new Vector2(i, 4.5f);
            Instantiate(enemy1PreFab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(2f);

        } 

        yield return new WaitForSeconds(5f);

        for(int i = 0; i < 3; i++){
            Vector2 spawnPos = new Vector2(16.5f, Random.Range(0,2f));
            Instantiate(enemy2PreFab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(2f);

        }

        yield return new WaitForSeconds(5f);

        for(int i = 0; i < 3; i++){
            Vector2 spawnPos = new Vector2(Random.Range(18,23), 4.5f);
            Vector2 spawnPos2 = new Vector2(Random.Range(18,23), 4.5f);
            Instantiate(enemy1PreFab, spawnPos, Quaternion.identity);
            Instantiate(enemy3PreFab, spawnPos2, Quaternion.identity);
            yield return new WaitForSeconds(5f);

        }

        yield return new WaitForSeconds(3f);

        for(int i = 18; i < 23; i += 2){
            Vector2 spawnPos = new Vector2(i, 4.5f);
            Instantiate(enemy3PreFab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(2f);

        } 


    }
}
