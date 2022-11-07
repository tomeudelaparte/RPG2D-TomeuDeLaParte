using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        UpdateMaxHealth(maxHealth);
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
