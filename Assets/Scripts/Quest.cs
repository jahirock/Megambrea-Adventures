using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;

    public string startText, completeText;
    public int experience;

    public bool needsItem;
    public string itemNeeded;

    public bool needsEnemy;
    public string enemyName;
    public int numberOfEnemies;
    private int enemiesKilled;

    // Update is called once per frame
    void Update()
    {
        if(needsItem && QuestManager.sharedInstance.itemCollected.Equals(itemNeeded))
        {
            QuestManager.sharedInstance.itemCollected = null;
            CompleteQuest();
        }

        if(needsEnemy && QuestManager.sharedInstance.enemyKilled.Equals(enemyName))
        {
            QuestManager.sharedInstance.enemyKilled = "";
            enemiesKilled++;
            if(enemiesKilled >= numberOfEnemies)
            {
                CompleteQuest();
            }
        }
    }

    public void StartQuest()
    {
        QuestManager.sharedInstance.ShowQuestText(startText);
    }

    public void CompleteQuest()
    {
        QuestManager.sharedInstance.ShowQuestText(completeText);
        QuestManager.sharedInstance.questCompleted[questID] = true;
        gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(experience);
    }
}
