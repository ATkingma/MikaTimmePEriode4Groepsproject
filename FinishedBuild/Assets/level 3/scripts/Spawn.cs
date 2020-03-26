using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public bool spawnBool;
    public GameObject heavyEnemie;
    public GameObject lightEnemie;
    public Vector3[] heavySpawn;
    public Vector3[] lightSpawn;
    public float timer;
    public float spawnTimer;
    private void Start()
    {
        spawnTimer = 10;
        spawnBool = true;
        heavySpawn[0].x = Random.Range(72.685f, 56.84f);
        heavySpawn[0].y = Random.Range(0.58f, 0.58f);
        heavySpawn[0].z = Random.Range(-20.118f, 4.6f);

        lightSpawn[0].x = Random.Range(72.685f, 56.84f);
        lightSpawn[0].y = Random.Range(0.58f, 0.58f);
        lightSpawn[0].z = Random.Range(-20.118f, 4.6f);

        heavySpawn[1].x = Random.Range(72.685f, 56.84f);
        heavySpawn[1].y = Random.Range(0.58f, 0.58f);
        heavySpawn[1].z = Random.Range(190.81f, 175.65f);

        lightSpawn[1].x = Random.Range(72.685f, 56.84f);
        lightSpawn[1].y = Random.Range(0.58f, 0.58f);
        lightSpawn[1].z = Random.Range(190.81f, 175.65f);

        heavySpawn[2].x = Random.Range(-130.89f, -140.66f);
        heavySpawn[2].y = Random.Range(0.58f, 0.58f);
        heavySpawn[2].z = Random.Range(190.81f, 175.65f);

        lightSpawn[2].x = Random.Range(-130.89f, -140.66f);
        lightSpawn[2].y = Random.Range(0.58f, 0.58f);
        lightSpawn[2].z = Random.Range(190.81f, 175.65f);

        heavySpawn[3].x = Random.Range(-130.89f, -140.66f);
        heavySpawn[3].y = Random.Range(0.58f, 0.58f);
        heavySpawn[3].z = Random.Range(20.118f, 4.6f);

        lightSpawn[3].x = Random.Range(-132.02f, -140.07f);
        lightSpawn[3].y = Random.Range(0.58f, 0.58f);
        lightSpawn[3].z = Random.Range(-18.96f, 7.24f);   
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnBool == true)
        {
            SpawnEnemie();
        }
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            if(timer <= 5.01)
            {
                spawnBool = true;
            }
        }
        if (spawnBool == true)
        {
            StartCoroutine(SpawnThem());
        }
    }
    public void SpawnEnemie()
    {
        Instantiate(heavyEnemie, heavySpawn[0], Quaternion.identity);
        Instantiate(lightEnemie, lightSpawn[0], Quaternion.identity);
        Instantiate(heavyEnemie, heavySpawn[1], Quaternion.identity);
        Instantiate(lightEnemie, lightSpawn[1], Quaternion.identity);
        Instantiate(heavyEnemie, heavySpawn[2], Quaternion.identity);
        Instantiate(lightEnemie, lightSpawn[2], Quaternion.identity);
        Instantiate(heavyEnemie, heavySpawn[3], Quaternion.identity);
        Instantiate(lightEnemie, lightSpawn[3], Quaternion.identity);      
    }
    IEnumerator SpawnThem()
    {
        spawnBool = false;      
        SpawnEnemie();
        yield return new WaitForSeconds(30);
        spawnBool = true;
    }
}