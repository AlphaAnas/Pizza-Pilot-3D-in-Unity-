using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "coinStats")
        {
            GetComponent<TextMesh>().text = "Coins: " + GMscript.coinTotal;
        }
        if (gameObject.name == "timeStats")
        {
            GetComponent<TextMesh>().text = "Game Time : " + GMscript.timeTotal;
        }

    }
}
