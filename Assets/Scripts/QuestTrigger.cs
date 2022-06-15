using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class QuestTrigger : MonoBehaviour
{
    public int questID;
    public bool startPoint, endPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!QuestManager.sharedInstance.questCompleted[questID])
            {
                if(startPoint && !QuestManager.sharedInstance.quests[questID].gameObject.activeInHierarchy)
                {
                    QuestManager.sharedInstance.quests[questID].gameObject.SetActive(true);
                    QuestManager.sharedInstance.quests[questID].StartQuest();
                }

                if(endPoint && QuestManager.sharedInstance.quests[questID].gameObject.activeInHierarchy)
                {
                    QuestManager.sharedInstance.quests[questID].CompleteQuest();
                }
            }
        }
    }
}
