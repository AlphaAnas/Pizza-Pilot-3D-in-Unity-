using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    public GameObject pizzaTextObject;
    public GameObject healthTextObject;

    private int pizzaCount = 2;
    private float healthPercentage = 100f;

    void Start()
    {
        UpdatePizzaText();
        UpdateHealthText();
    }

    // Call this function whenever the pizza count changes
    public void UpdatePizzaCount(int newPizzaCount)
    {
        pizzaCount = newPizzaCount;
        UpdatePizzaText();
    }

    // Call this function whenever the health changes
    public void UpdateHealth(float newHealthPercentage)
    {
        healthPercentage = newHealthPercentage;
        UpdateHealthText();
    }

    private void UpdatePizzaText()
    {
        Text pizzaText = pizzaTextObject.GetComponent<Text>();
        pizzaText.text = pizzaCount + " x";
    }

    private void UpdateHealthText()
    {
        Text healthText = healthTextObject.GetComponent<Text>();
        healthText.text = healthPercentage.ToString("0") + "%";
    }
}

