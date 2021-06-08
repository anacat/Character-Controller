using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Dialogue dialogue;

    private DialogueUIController _dialogueController;

    private void Awake()
    {
        _dialogueController = FindObjectOfType<DialogueUIController>();
    }

    private void OnMouseDown()
    {
        if (!_dialogueController.IsShowingDialogue())
        {
            _dialogueController.ShowDialogueBox(dialogue);
        }
    }
}
