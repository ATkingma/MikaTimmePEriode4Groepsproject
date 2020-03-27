using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Mouselook : MonoBehaviour
{
    public GameObject groep1;
    public GameObject groep2;

    public GameObject image1;
    public GameObject image2;

    public Text dot;
    public Text handgunmeg;
    public Text famasmeg;

    public Animator schooting;

    public bool doAnimation;
    public bool bosalive;
    public GameObject door;
    public float bossHP;
    public GameObject boss;

    public float time;
    public float impactforce = 30F;
    public float Mousesence = 100f;
    float xRotation = 0f;
    public Transform Player;
    public int Punten;
    public int kills;

    public float magHandGun;
    public float magFamas;

    public WeaponSwitch weaponswitch;

    RaycastHit hit;
    public float radius;
    public float power;
    public float explosionSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        door.SetActive(false);

        bosalive = true;
        magHandGun = 10;
        magFamas = 30;

    }
    void Update()
    {
       
        DoCast();
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
        {
            image1.SetActive(true);
            image2.SetActive(false);
            groep1.SetActive(true);
            groep2.SetActive(false);
        }
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
        {
            image1.SetActive(false);
            image2.SetActive(true);
            groep1.SetActive(false);
            groep2.SetActive(true);

        }

        handgunmeg.text = magHandGun.ToString();
        famasmeg.text = magFamas.ToString();



        time += Time.deltaTime;

        if (bossHP <= 0)
        {
            if (time >= 0.2)
            {
                bosalive = false;
            }
        }


        if (magFamas >= 31)
        {
            magFamas = 30;
        }
        if (magFamas <= 0)
        {
            magFamas = 0;
        }
        if (magHandGun >= 11)
        {
            magHandGun = 10;
        }
        if (magHandGun <= 0)
        {
            magHandGun = 0;
        }

        if (bosalive == true)
        {
            bossHP = boss.GetComponent<Health>().health;
        }
        if (bosalive == false)
        {
            StartCoroutine(Door());
        }

        if (Input.GetKey("r"))
        {
            StartCoroutine(Reload());
        }
        float mouseX = Input.GetAxis("Mouse X") * Mousesence * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Mousesence * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -10, 15);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        Vector3 rot = new Vector3(0, mouseX, 0);
        Player.Rotate(rot);
       
    }

    IEnumerator Exo()
    {
        yield return new WaitForSeconds(0f);

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
        }
    }
    IEnumerator Door()
    {
        yield return new WaitForSeconds(1f);
        door.SetActive(true);
    }
    public IEnumerator Reload()
    {
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
        {
            yield return new WaitForSeconds(1);
            {
                magHandGun += 10;
            }
        }
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
        {
            yield return new WaitForSeconds(4);
            {
                magFamas += 30;
            }
        }



    }
    public void MagazijnMin()
    {
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
        {
            if (magHandGun >= 1)
            {
                magHandGun -= 1;
            }
        }
        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
        {
            if (magFamas >= 1)
            {
                magFamas -= 1;
            }
        }
       

    }
    //hier gaat hij schieten
    void DoCast()
    {

        if (Input.GetButtonDown("Fire1"))
        {
                        if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
                        {
                if (magHandGun >= 1)
                {
                    StartCoroutine(DoShoot());
                }
              
                        }
            MagazijnMin();
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                if (hit.transform.tag == "Boss")
                {
                    Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.red, 100);
                    if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
                    {
                        if (magHandGun >= 1)
                        {
                           
                            hit.transform.GetComponent<Health>().DoDamage(5);
                            print("boshit1");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }

                    }
                    else if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
                    {
                        if (magFamas >= 1)
                        {
                            hit.transform.GetComponent<Health>().DoDamage(10);
                            print("boshit2");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }
                    }
                }
            

            if (hit.transform.tag == "Heavy")
            {
                Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.green, 100);
                if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
                {
                    if (magHandGun >= 1)
                    {
                           
                            hit.transform.GetComponent<Health>().DoDamage(5);
                        print("heavyhit1");
                    }
                    else
                    {
                        hit.transform.GetComponent<Health>().DoDamage(0);
                    }
                }
                else if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
                {
                    if (magFamas >= 1)
                    {
                        hit.transform.GetComponent<Health>().DoDamage(10);
                        print("heavyhit2");
                    }
                    else
                    {
                        hit.transform.GetComponent<Health>().DoDamage(0);
                    }
                }

            }


                if (hit.transform.tag == "Light")
                {
                    Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.blue, 100);

                    if (GetComponent<WeaponSwitch>().currentWeaponIndex == 0)
                    {
                        if (magHandGun >= 1)
                        {

                            hit.transform.GetComponent<Health>().DoDamage(5);
                            print("lighthit1");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }

                    }
                    else if (GetComponent<WeaponSwitch>().currentWeaponIndex == 1)
                    {
                        if (magFamas >= 1)
                        {
                            hit.transform.GetComponent<Health>().DoDamage(10);
                            print("lighthit2");
                        }
                        else
                        {
                            hit.transform.GetComponent<Health>().DoDamage(0);
                        }
                    }
                  

                }


        }
         

    }



        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        { 
            
            
                if (hit.transform.tag == "DoorLevel4")
                {
                    if (Input.GetButton("e"))
                    {
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene(sceneBuildIndex: 6);
                    }
                }
                if (bossHP <= 0)
                {
                    DoorSpawn();
                }
                if (hit.transform.tag == "GodWeapon1")
                {
                    if (Input.GetButton("e"))
                    {
                        weaponswitch.godWeapon1 = true;
                    }
                }
                if (hit.transform.tag == "GodWeapon2")
                {
                    if (Input.GetButton("e"))
                    {
                        weaponswitch.godWeapon2 = true;
                    }
                }
           
        }
     
    }
    IEnumerator DoShoot()
    {
        
              schooting.Play("Schoot");
        yield return new WaitForSeconds(0.1f);
        
    }

   
   
    public void DoorSpawn()
    {
        door.SetActive(true);
    }
}