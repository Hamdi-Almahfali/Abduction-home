using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrDialogueBox : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextComponent;
    public string[] textLines;
    public float textSpeed;

    private int index;
    private string sender;
    private bool finishedLines; // Bool for if the box has done writing all the lines

    void Start()
    {
        dialogueTextComponent.text = string.Empty;
        StartDialogue(textLines);
    }

    void Update()
    {
        CheckInput();
    }
    public void StartDialogue(string[] lines, string sender = "", float speed = 0.05f)
    {
        index = 0;
        textLines = lines;
        textSpeed = speed;
        this.sender = sender;
        finishedLines = false;

        StartCoroutine(TypeLine());

    }
    IEnumerator TypeLine()
    {
        // Only adds ':' if there is a sender
        if (sender != "")
            dialogueTextComponent.text += $"{sender}: ";


        foreach (char c in textLines[index].ToCharArray()) {
            dialogueTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        finishedLines = true;
    }
    void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (dialogueTextComponent.text != textLines[index])
            {
                StopAllCoroutines();
                dialogueTextComponent.text = textLines[index];
                return;
            }
            else if (index >= textLines.Length - 1)
            {
                CloseDialogueBox();
                return;
            }
            NextLine();
        }
    }
    void NextLine()
    {
        if (index < textLines.Length - 1)
        {
            index++;
            ClearDialogueBox();
            StartCoroutine(TypeLine());
        }
    }
    void ClearDialogueBox()
    {
        dialogueTextComponent.text = string.Empty;
    }
    void CloseDialogueBox()
    {
        ClearDialogueBox();
        gameObject.SetActive(false);
    }
}
