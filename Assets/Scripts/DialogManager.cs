using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive;

    public string[] dialogLines;
    public int currentDialogLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogActive && Input.GetKeyDown(KeyCode.Return))
        {
            currentDialogLine++;
        }

        if(currentDialogLine >= dialogLines.Length)
        {
            StartCoroutine(EndDialog());
        }
        else
        {
            dialogText.text = dialogLines[currentDialogLine];
        }
    }

    IEnumerator EndDialog()
    {
        yield return new WaitForSeconds(0.3F);
        HideDialog();
        currentDialogLine = 0;
    }

    public void ShowDialog(string[] lines)
    {
        dialogActive = true;
        dialogBox.SetActive(true);
        currentDialogLine = 0;
        dialogLines = lines;
    }

    public void HideDialog()
    {
        dialogActive = false;
        dialogBox.SetActive(false);
    }
}
