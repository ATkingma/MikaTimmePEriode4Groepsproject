    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text kill;
    public Text poin;
    public int kills;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        kill.text = kills.ToString();
        poin.text = points.ToString();
    }
}
