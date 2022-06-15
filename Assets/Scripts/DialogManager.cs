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

    public static DialogManager sharedInstace;

    // Start is called before the first frame update
    void Start()
    {
        if(sharedInstace == null)
        {
            sharedInstace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogActive && Input.GetKeyDown(KeyCode.Return))
        {
            currentDialogLine++;
        }

        if(dialogActive && currentDialogLine >= dialogLines.Length)
        {
            HideDialog();
        }
        else if(dialogLines.Length > 0)
        {
            dialogText.text = dialogLines[currentDialogLine];
        }
    }

    IEnumerator EndDialog()
    {
        yield return new WaitForSeconds(0.1F);
        currentDialogLine = 0;
        dialogActive = false;
    }

    public void ShowDialog(string[] lines)
    {
        Debug.Log("Se muestra el dialogo?");
        dialogBox.SetActive(true);
        currentDialogLine = 0;
        dialogLines = lines;
        dialogActive = true;
        Debug.Log(": " + dialogBox.activeInHierarchy);
    }

    public void HideDialog()
    {
        Debug.Log("Se cierra el dialogo");
        //dialogActive = false;
        dialogBox.SetActive(false);
        StartCoroutine(EndDialog());
    }
}
