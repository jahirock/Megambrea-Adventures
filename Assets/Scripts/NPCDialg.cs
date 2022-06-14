using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialg : MonoBehaviour
{
    public string[] dialog;
    private DialogManager manager;
    private bool playerInTheZone;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTheZone = false;
            manager.HideDialog();
        }
    }

    void Update()
    {
        if(playerInTheZone && Input.GetKeyDown(KeyCode.Return) && !manager.dialogActive)
        {
            manager.ShowDialog(dialog);
            if(gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
        }
    }
}
