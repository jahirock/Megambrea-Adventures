using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;

    public Slider playerExpBar;
    public Text playerExpText;
    public Text playerLevelText;

    public HealthManager playerHealthManager;
    public CharacterStats playerStats;

    void Update()
    {
        //Por si subimos de nivel
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;

        StringBuilder sb = new StringBuilder("HP: ");
        sb.Append(playerHealthManager.currentHealth);
        sb.Append("/");
        sb.Append(playerHealthManager.maxHealth);
        playerHealthText.text = sb.ToString();

        playerExpBar.maxValue = playerStats.expToLevelUp[playerStats.currentLevel];
        playerExpBar.value = playerStats.currentExp;

        sb = new StringBuilder("Exp: ");
        sb.Append(playerStats.currentExp);
        sb.Append("/");
        sb.Append(playerStats.expToLevelUp[playerStats.currentLevel]);
        playerExpText.text = sb.ToString();

        playerLevelText.text = playerStats.currentLevel.ToString();
    }
}
