using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    public int expWhenDefeated;

    private SpriteRenderer characterRenderer;

    public string enemyName;

    private SFXManager sfxManager;

    void Start()
    {
        currentHealth = maxHealth;
        characterRenderer = GetComponent<SpriteRenderer>();
        sfxManager = FindObjectOfType<SFXManager>();
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            if(gameObject.CompareTag("Enemy"))
            {
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated);

                QuestManager.sharedInstance.enemyKilled = enemyName;
            }

            gameObject.SetActive(false);
        }

        if (flashActive)
        {
            flashCounter -= Time.deltaTime;

            if (flashCounter > flashLength * 0.66F)
            {
                ToggleColor(false);
            }
            else if (flashCounter > flashLength * 0.33F)
            {
                ToggleColor(true);
            }
            else if (flashCounter > 0)
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                flashActive = false;
            }
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if(flashLength > 0)
        {
            flashActive = true;
            flashCounter = flashLength;
        }

        if (gameObject.CompareTag("Player"))
        {
            if(currentHealth <= 0)
            {
                sfxManager.playerDead.Play();
            }
            else
            {
                sfxManager.playerHurt.Play();
            }
        }
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

    private void ToggleColor(bool visible)
    {
        characterRenderer.color = new Color(
            characterRenderer.color.r,
            characterRenderer.color.g,
            characterRenderer.color.b,
            (visible ? 1.0F : 0.0F)
        );
    }
}
