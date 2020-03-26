using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemieScript : MonoBehaviour
{
    public int killCound;
    public float health;
    public Vector3 goal;
     void Update()
    {
        health = GetComponent<Health>().health;


        goal = GameObject.FindGameObjectWithTag("Player").transform.position;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal;
       
        if (health <= 0)
        {
            killCound += 1;


        }
        health = GetComponent<Health>().health;
    }
   
}
