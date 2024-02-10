using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    List<DialogEntry> dialogEntries;
    string displayedDialog = null;

    int pageIndex = 0;
    int wordIndex = 0;

    [Range(1f,0.01f)] public float pageSpeed = 1f;
    float timer = 0f;

    bool isReading = false;    // Ativa o evento de leitura
    bool isWaiting = false;    // Aguarda a ação de continuar do jogador

    public TMP_Text textComponent;

    void Update()
    {
        if (!isReading) return;

        if (isWaiting)
        {
            if (Input.GetMouseButtonDown(0)) isWaiting = false;
            return;
        }

        textComponent.text = displayedDialog;

        // Valida se ainda possui diálogos para serem lidos
        // Caso não possua, o evento irá desativar o modo leitura e resetar as variáveis
        if (pageIndex >= dialogEntries.Count)
        {
            ResetDialogState();
            return;
        }

        timer += Time.deltaTime;

        string currentDialog = dialogEntries[pageIndex].dialogText;

        if (timer > pageSpeed)
        {
            if (wordIndex >= currentDialog.Length)
            {
                pageIndex++;
                wordIndex = 0;
                displayedDialog = null;
                isWaiting = true;
                return;
            }
            displayedDialog += currentDialog[wordIndex];
            wordIndex++;
            timer = 0;
        }
    }

    public void InitiateDialog(List<DialogEntry> entries)
    {
        dialogEntries = entries;
        isReading = true;
    }

    private void ResetDialogState()
    {
        pageIndex = 0;
        isReading = false;
        isWaiting = false;
        displayedDialog = null;
    }
}
