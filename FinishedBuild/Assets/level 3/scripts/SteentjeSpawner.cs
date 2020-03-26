using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteentjeSpawner : MonoBehaviour
{
    public GameObject stone;
    public Vector2 randomPosses;
    public int stonesToSpawn;
    // Start is called before the first frame update
    void Start()    
    {
        for (int i = 0; i < stonesToSpawn; i++)
        {
            Instantiate(stone, GetRandomPos(), Quaternion.identity);
        }
    }

    Vector3 GetRandomPos()
    {
        Vector3 newRandomPos = new Vector3();
        newRandomPos.y = 0.5f;
        newRandomPos.x = Random.Range(-randomPosses.x, randomPosses.x);
        newRandomPos.z = Random.Range(-randomPosses.y, randomPosses.y);
        return newRandomPos;
    }
}