using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUIController : MonoBehaviour
{
    public CanvasGroup dialogueGroup;

    [Header("UI")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private bool _isShowingDialogue = false;
    private int _currentLine;
    private Dialogue _currentDialogue;

    public void ShowDialogueBox(Dialogue dialogue)
    {
        dialogueGroup.alpha = 1f;
        dialogueGroup.interactable = true;
        dialogueGroup.blocksRaycasts = true;

        _currentLine = 0; //fala atual; começa no 0
        _currentDialogue = dialogue;
        _isShowingDialogue = true;

        nameText.text = dialogue.characterName;
        dialogueText.text = dialogue.dialogue[_currentLine];
    }

    public void NextLine()
    {
        if (!_isShowingDialogue)
        {
            return;
        }

        if (_currentLine + 1 < _currentDialogue.dialogue.Count)
        {
            _currentLine++;
            dialogueText.text = _currentDialogue.dialogue[_currentLine];
        }
        else
        {
            HideDialogueBox();
        }
    }

    public void HideDialogueBox()
    {
        _isShowingDialogue = false;

        dialogueGroup.alpha = 0f;
        dialogueGroup.interactable = false;
        dialogueGroup.blocksRaycasts = false;
    }

    public bool IsShowingDialogue()
    {
        return _isShowingDialogue;
    }
}
