using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismNeeds : MonoBehaviour
{
    // Variables for hunger, energy, fun, and social
    private float hunger = 100f;
    private float energy = 100f;
    private float fun = 100f;
    private float social = 100f;

    // Update is called once per frame
    void Update()
    {
        // Simulate the passage of time
        HandleTime();

        // Check and update the status of hunger, energy, fun, and social
        HandleHunger();
        HandleEnergy();
        HandleFun();
        HandleSocial();
    }

    void HandleTime()
    {
        // Simulate the passage of time, decrementing values gradually
        hunger -= Time.deltaTime * 0.1f;
        energy -= Time.deltaTime * 0.05f;
        fun -= Time.deltaTime * 0.08f;
        social -= Time.deltaTime * 0.06f;

        // Ensure values stay within a valid range
        hunger = Mathf.Clamp(hunger, 0f, 100f);
        energy = Mathf.Clamp(energy, 0f, 100f);
        fun = Mathf.Clamp(fun, 0f, 100f);
        social = Mathf.Clamp(social, 0f, 100f);
    }

    void HandleHunger()
    {
        // Handle hunger logic here
        if (hunger < 30f)
        {
            // Prism is hungry, perform actions like eating
        }
    }

    void HandleEnergy()
    {
        // Handle energy logic here
        if (energy < 10f)
        {
            // Prism is tired, perform actions like resting
        }
    }

    void HandleFun()
    {
        // Handle fun logic here
        if (fun < 20f)
        {
            // Prism is bored, perform actions like playing
        }
    }

    void HandleSocial()
    {
        // Handle social logic here
        if (social < 40f)
        {
            // Prism is lonely, perform actions like interacting with others
        }
    }
}
