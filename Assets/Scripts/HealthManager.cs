using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;    
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
