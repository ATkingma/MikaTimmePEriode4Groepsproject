using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class BosRage : MonoBehaviour
{
  
    public Slider BosSlider;
    public Material[] mat;
    public Renderer ren;
    public GameObject skeletenmeshrender;
    public Vector3 newGoal;
    public bool trigger;
    public GameObject Object;
    public float timer;
    public float healthEindBos;
    public GameObject[] objects;
    public GameObject[]vloerobjects;
    public Material pilaarPaars;
    public Material pilaarRood;
    public Material pilaarBlauw;
    public Material pilaarBlauwLicht;
    public Material pilaarGroen;
    public Material vloerneutraal;  
    public Material vloerpaars;
    public Material vloerrood;
    public Material vloerblauw;
    public Material vloerblauwl;
    public Material vloergroen;
    public Material hooftpaars;
    public Material hooftrood;
    public Material hooftblauw;
    public Material hooftblauwl;
    public Material hooftgroen;
    public Material bodypaars;
    public Material bodyrood;
    public Material bodyblauw;
    public Material bodyblauwl;
    public Material bodygroen;
    public Material sythPaars;
    public Material sythRood;
    public Material sythBlauw;
    public Material sythBlauwL;
    public Material sythGroen;
    public Material voeten;
    public Material handen;
    public float rondjes;
    public Material normalemuur;
    public GameObject vloer;
    public float tijd = 0.00f;
    public Text timetext;
    public GameObject somethink;
    public Vector3 goal;
    public  GameObject iets;
    public float rage;
    public float rage2;
    public Health health;
    // Start is called before the first frame update
    public void Start()
    {

        tijd = 0.1f;
        ren = skeletenmeshrender.GetComponent<SkinnedMeshRenderer>();
        mat = ren.materials;
        BeginLicht();
        ren.materials[3] = hooftgroen;
        
    }


    // Update is called once per frame
    public void BossSpeedFix()
    {
        healthEindBos = 901;
        GetComponent<Health>().health = 901;
    }
    public  void Update()
    {
        
        BosSlider.value = healthEindBos;
        healthEindBos = GetComponent<Health>().health;
        GetComponent<Health>().health = healthEindBos;
        if (tijd == 0.1f)
        {
            BeginLicht();

            
        }
       
        if (rage == 0)
        {
            FindPlayer();
        }
        if (rage == 1)
        {
            Rage1punt1();
        }
        if (rage == 2)
        {
            Rage1punt2();
        }
        if (rage == 3)
        {
            Rage1punt3();
        }
        if (rage == 4)
        {
            Rage1punt4();
        }
        if (rage == 5)
        {
            Rage2punt1();
        }
        if (rage == 6)
        {
            Rage2punt2();
        }
        if (rage == 7)
        {
            Rage2punt3();
        }
        if (rage == 8)
        {
            Rage2punt4();
        }

        Rage();
        objects = GameObject.FindGameObjectsWithTag("pilar");
        vloerobjects = GameObject.FindGameObjectsWithTag("objects");
     
        if (healthEindBos == 850)
        {
            rage = 1;
            GetComponent<NavMeshAgent>().speed = 60;
            mat[0] = bodygroen;
            mat[3] = hooftgroen;
            mat[4] = sythGroen;
            Invoke("BossSpeedFix", 50);
            ren.materials = mat;
           
            GetComponent<Health>().health = healthEindBos;

            

            tijd += 1;
            foreach (GameObject pilar in objects)
            {
            pilar.GetComponent<Renderer>().material = pilaarGroen;


                tijd += 1;
            }   
        }  
        if(healthEindBos == 901)
        {
            GetComponent<NavMeshAgent>().speed = 5;
        }
        if (healthEindBos == 551)
        {
            rage = 0;
            mat[0] = bodyblauwl;
            mat[3] = hooftblauwl;
            mat[4] = sythBlauwL;
            ren.materials = mat;
            foreach (GameObject pilar in objects)
            {
                pilar.GetComponent<Renderer>().material = pilaarBlauwLicht;

            }
        }
        if (healthEindBos == 251)
        {
            rage = 0;
            mat[0] = bodyblauw;
            mat[3] = hooftblauw;
            mat[4] = sythBlauw;
            ren.materials = mat;
            foreach (GameObject pilar in objects)
            {
                pilar.GetComponent<Renderer>().material = pilaarBlauw;

            }
        }
        if (healthEindBos == 151)
        {
            rage = 0;
            mat[0] = bodyrood;
            mat[3] = hooftrood;
            mat[4] = sythRood;
            ren.materials = mat;
            foreach (GameObject pilar in objects)
            {
                pilar.GetComponent<Renderer>().material = pilaarRood; 
                      
      
            }
        }
        if (Input.GetButton("z"))
        {
            Invoke("Paars", 0.1f);
            tijd = 0.2f;
        }


        timer += Time.deltaTime;
     }
    public void OnTriggerEnter(Collider col)
    {
        if (rage == 1)
        {
            if (col.tag == "rage 1.1")
            {
                rage = 2;
                print("pan");
            }
        }
        if (rage == 2)
        {
            if (col.tag == "rage 1.2")
            {
                rage = 3;
                print("pane");
            }
        }
        if (rage == 3)
        {
            if (col.tag == "rage 1.3")
            {
                rage = 4;
                print("panekoek");
            }
        }
        if (rage == 4)
        {
            if (col.tag == "rage 1.4")
            {
                rage = 5;
                print("panekoeken");
            }
        }
        if (rage == 5)
        {
            if (col.tag == "rage 2.1")
            {
                rage = 6;

            }
        }
        if (rage == 6)
        {
            if (col.tag == "rage 2.2")
            {
                rage = 7;

            }
        }
        if (rage == 7)
        {
            if (col.tag == "rage 2.3")
            {
                rage = 8;

            }
        }
        if (rage == 8)
        {
            if (col.tag == "rage 2.4")
            {
                rage = 0;
                FindPlayer();
            }
        }
        BosSlider.value = healthEindBos;    
    }
    public void Rage()
    {

        goal = somethink.transform.position;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal;

    }
    public void FindPlayer()
    {
        somethink = GameObject.FindGameObjectWithTag("Player");
    }
    public void Rage1punt1()
    {
        somethink = GameObject.FindGameObjectWithTag("rage 1.1");
        
    }
    public void Rage1punt2()
    {
        somethink = GameObject.FindGameObjectWithTag("rage 1.2");

    }
    public void Rage1punt3()
    {
        somethink = GameObject.FindGameObjectWithTag("rage 1.3");
    }
    public void Rage1punt4()
    {
        somethink = GameObject.FindGameObjectWithTag("rage 1.4");
    }
    public void Rage2punt1()
    {
        somethink = GameObject.FindGameObjectWithTag("rage 2.1");
    }
    public void Rage2punt2()
    {
        somethink = GameObject.FindGameObjectWithTag("rage 2.2");
    }
    public void Rage2punt3()
    {
        somethink = GameObject.FindGameObjectWithTag("rage 2.3");
    }
    public void Rage2punt4()
    {
        somethink = GameObject.FindGameObjectWithTag("rage 2.4");
        rage = 0;

    }
    public void Paars()
    {
        mat[0] = bodypaars;
        mat[3] = hooftpaars;
        mat[4] = sythPaars;
        ren.materials = mat;
        Invoke("Groen", 0.1f);
        foreach (GameObject pilar in objects)
        {
            pilar.GetComponent<Renderer>().material = pilaarPaars;
           
        }
        foreach (GameObject ojects in vloerobjects)
        {
            ojects.GetComponent<Renderer>().material = vloerpaars;

        }
    }
    public void Groen()
    {
        mat[0] = bodygroen;
        mat[3] = hooftgroen;
        mat[4] = sythGroen;
        ren.materials = mat;
        Invoke("Rood", 0.1f);
        foreach (GameObject pilar in objects)
        {
            pilar.GetComponent<Renderer>().material = pilaarGroen;
            
        }
        foreach (GameObject ojects in vloerobjects)
        {
            ojects.GetComponent<Renderer>().material = vloergroen;

        }
    }
    public void Rood()
    {
        mat[0] = bodyrood;
        mat[3] = hooftrood;
        mat[4] = sythRood;
        ren.materials = mat;
        Invoke("Blauw", 0.1f);
        foreach (GameObject pilar in objects)
        {
            pilar.GetComponent<Renderer>().material = pilaarRood;
            
        }
        foreach (GameObject ojects in vloerobjects)
        {
            ojects.GetComponent<Renderer>().material = vloerrood;

        }
    }
    public void Blauw()
    {
        mat[0] = bodyblauw;
        mat[3] = hooftblauw;
        mat[4] = sythBlauw;
        ren.materials = mat;
        Invoke("BlauwLicht", 0.1f);
        foreach (GameObject pilar in objects)
        {
            pilar.GetComponent<Renderer>().material = pilaarBlauw;
        }
        foreach (GameObject ojects in vloerobjects)
        {
            ojects.GetComponent<Renderer>().material = vloerblauw;

        }
    }
    public void BlauwLicht()
    {
        mat[0] = bodyblauwl;
        mat[3] = hooftblauwl;
        mat[4] = sythBlauwL;
        ren.materials = mat;
        if (trigger == true)
        {
           
        }
        else
        {
            foreach (GameObject pilar in objects)
            {
                pilar.GetComponent<Renderer>().material = pilaarBlauwLicht;
            }
            foreach (GameObject ojects in vloerobjects)
            {
                ojects.GetComponent<Renderer>().material = vloerblauwl;

            }
            Invoke("Paars", 0.1f);
        }
    }
    public void BeginLicht()
    {

        foreach (GameObject pilar in objects)
        {
            pilar.GetComponent<Renderer>().material = pilaarPaars;
           
        }
        foreach (GameObject ojects in vloerobjects)
        {
            ojects.GetComponent<Renderer>().material = normalemuur;
            vloer.GetComponent<Renderer>().material = vloerneutraal;


        }
    }

}