using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public bool[] questCompleted;
    public string itemCollected;

    public string enemyKilled;

    public static QuestManager sharedInstance;

    // Start is called before the first frame update
    void Start()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        questCompleted = new bool[quests.Length];
    }

    public void ShowQuestText(string questText)
    {
        string[] dialogLines = new string[] { questText };

        DialogManager.sharedInstace.ShowDialog(dialogLines);
    }
}
