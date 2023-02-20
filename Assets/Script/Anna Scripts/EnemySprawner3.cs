using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprawner3 : MonoBehaviour
{
    public GameObject enemy1PreFab;
    public GameObject enemy2PreFab;
    public GameObject enemy3PreFab;
    public GameObject enemy4PreFab;

    IEnumerator Start(){
        yield return new WaitForSeconds(3f);

        for(int i = 0; i < 3; i++){
            Vector2 spawnPos = new Vector2(-8, 1);
            Instantiate(enemy4PreFab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(5f);

        }

        for(int i = 0; i < 4; i++){
            Vector2 spawnPos = new Vector2(-8, Random.Range(3,5));
            Instantiate(enemy2PreFab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(2f);

        }

        yield return new WaitForSeconds(5f);

        for(int i = 0; i < 5; i++){
            Vector2 spawnPos = new Vector2(Random.Range(-8,8), 5);
            Instantiate(enemy3PreFab, spawnPos, Quaternion.identity);
            Vector2 spawnPos2 = new Vector2(Random.Range(-8,8), 5);
            Instantiate(enemy3PreFab, spawnPos2, Quaternion.identity);
            yield return new WaitForSeconds(7f);

        }

        yield return new WaitForSeconds(5f);

        for(int i = -8; i < 9; i += 3){
            Vector2 spawnPos = new Vector2(i, 5);
            Instantiate(enemy1PreFab, spawnPos, Quaternion.identity);

        } 

        yield return new WaitForSeconds(8f);

        for(int i = -8; i < 9; i += 3){
            Vector2 spawnPos = new Vector2(i, 5);
            Instantiate(enemy3PreFab, spawnPos, Quaternion.identity);

        } 






    }
}
