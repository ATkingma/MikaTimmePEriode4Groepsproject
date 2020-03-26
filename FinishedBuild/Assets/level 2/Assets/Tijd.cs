using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tijd : MonoBehaviour
{

    public Text timeText;
    public float time;

    // Update is called once per frame
    void Update()
    {
        timeText.text = time.ToString("0.000");
        time = Time.timeSinceLevelLoad;

    }
}