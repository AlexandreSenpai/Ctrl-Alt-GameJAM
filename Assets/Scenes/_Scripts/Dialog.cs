using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogEntry 
{
    public string characterName;
    [TextArea] public string dialogText;
}

public class Dialog : MonoBehaviour 
{
    [SerializeField] DialogManager dialogManager;
    [SerializeField] List<DialogEntry> dialogEntries;

    public void StartSpeech() 
    {
        // Chama o evento principal do dialog manager para iniciar o evento de conversa
        dialogManager.InitiateDialog(dialogEntries);
    }
}
