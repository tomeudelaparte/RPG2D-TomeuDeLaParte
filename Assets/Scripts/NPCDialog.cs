using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class NPCDialog : MonoBehaviour
{
    public string npcName;
    private DialogManager dialogManager;
    private bool isPlayerInDialogZone;

    [TextArea]
    public string[] npcDialogLines;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    private void Update()
    {
        if (isPlayerInDialogZone && Input.GetMouseButtonDown(1))
        {
            dialogManager.ShowDialog(DialogPlusNPCName());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            isPlayerInDialogZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            isPlayerInDialogZone = false;
        }
    }

    private string[] DialogPlusNPCName()
    {
        string[] finalDialog = new string[npcDialogLines.Length];


        for (int i = 0; i < npcDialogLines.Length; i++)
        {
            if (npcName != null)
            {
                finalDialog[i] = $"{npcName}\n {npcDialogLines[i]}";
            }
            else
            {
                finalDialog[i] = npcDialogLines[i];
            }
        }

        return finalDialog;
    }
}
