using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static float vertVelocity = 0;
    public static int coinTotal=102; // this static variable can be used in different scirpts 
    public static float timeTotal = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTotal += Time.deltaTime;
    }
}
