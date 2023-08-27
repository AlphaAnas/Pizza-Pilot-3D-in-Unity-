using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static float vertVelocity = 0;
    public static float forward = 10;
    public static int coinTotal=102; // this static variable can be used in different scirpts 
    public static float timeTotal = 0f;
    public static float zValueAdjustment = 1;
    public static string gameCompStatus = "";
    public static float horVelocity = 0;
    public float waitToLoad = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTotal += Time.deltaTime;
        if( gameCompStatus == "No")
            {
            waitToLoad+=  Time.deltaTime;
        }

        if(waitToLoad > 2)
        {
            SceneManager.LoadScene("LevelComplete");
        }
    }
}
