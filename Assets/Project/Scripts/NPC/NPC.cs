using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogue;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public bool canInteract()
    {
        return !isDialogueActive;
    }
    public void Interact()
    {
        if (dialogue == null || !isDialogueActive)
        {
            return;
        }
        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
          StartDialogue();
        }
    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;
        nameText.SetText(dialogue.name);
        portraitImage.sprite = dialogue.npcPortrait;
        dialoguePanel.SetActive(true);

        //TypeLine
        StartCoroutine(TypeLine());
    }
    private void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogue.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if (++dialogueIndex < dialogue.dialogueLines.Length) 
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }
    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");
        foreach (char letter in dialogue.dialogueLines[dialogueIndex]) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
        if (dialogue.autoProgressLines.Length > dialogueIndex && dialogue.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogue.autoProgressDelay);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);

    }
}
