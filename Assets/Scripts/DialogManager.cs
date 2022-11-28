using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogTextBox;
    public bool isDialogActive;

    [TextArea]
    public string[] dialogLines;
    public int currentDialogLine;

    private void Start()
    {
        HideDialog();
    }

    private void Update()
    {
        if (isDialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogLine++;

            if (currentDialogLine >= dialogLines.Length)
            {
                HideDialog();
            }
            else
            {
                dialogTextBox.text = dialogLines[currentDialogLine];
            }
        }
    }

    public void ShowDialog(string[] lines)
    {
        currentDialogLine = 0;
        dialogLines = lines;

        isDialogActive = true;
        dialogPanel.SetActive(isDialogActive);
        dialogTextBox.text = dialogLines[currentDialogLine];
    }

    public void HideDialog()
    {
        isDialogActive = false;
        dialogPanel.SetActive(isDialogActive);
    }
}
