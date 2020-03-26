using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossDoDamage : MonoBehaviour
{
    public GameObject Score;
    public bool atacks;
public bool alive;
public bool isAtacking;
public float health;
public Animator anim;
public bool hitplayer;
public Transform player;
RaycastHit hit;
public bool smack;
// Start is called before the first frame update
void Start()
{
    alive = true;
    isAtacking = false;
    smack = false;
    atacks = false;
}


// Update is called once per frame
void Update()
{
        Score = GameObject.FindGameObjectWithTag("Score");
        health = GetComponent<Health>().health;
    if (health <= 0)
    {
        alive = false;
        GetComponent<NavMeshAgent>().speed = 0;
        StartCoroutine(Death());
    }
    DoCast();
    if (player)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toOther = player.position - transform.position;

        if (Vector3.Dot(forward, toOther) < 0)
        {
            //achter

        }
        if (Vector3.Dot(forward, toOther) > 0)
        {
            //voor
            if (alive == true)
            {
                
                if (hitplayer == true)
                {
              
                    if (isAtacking == false)
                    {
                     
                        StartCoroutine(Atack());
                    }
                }
                else
                {
                    anim.SetInteger("condition", 2);
                }
            }

        }

    }
}

void DoCast()
{
    Debug.DrawRay(transform.position, transform.forward * 10, Color.green, 10);

    if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
    {
        if (hit.transform.tag == "Player")
        {
            hitplayer = true;
          
        }
        else
        {
          
            hitplayer = false;
        }
    }
}
IEnumerator Atack()
{
    isAtacking = true;
    Smack();
    DoDamage();
 
    yield return new WaitForSeconds(2);
 
    isAtacking = false;
    hitplayer = false;
    smack = false;
}
public void DoDamage()
{
    if (hitplayer == true)
    {
      
        player.GetComponent<Playerhealth>().DoDamage(5);
    }
}
public void Smack()
{
    if (hitplayer == true)
    {
        if (smack == false)
        {
            anim.SetInteger("condition", 1);
            smack = true;
           

        }

    }
}
IEnumerator Death()
{

    anim.Play("BossDeath");
    yield return new WaitForSeconds(3);
        Score.GetComponent<Score>().kills++;
        Score.GetComponent<Score>().points += 10000;
        Destroy(gameObject);

}
}
