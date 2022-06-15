using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    //private QuestManager manager;

    public string startText, completeText;

    // Start is called before the first frame update
    void Start()
    {
        //manager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
