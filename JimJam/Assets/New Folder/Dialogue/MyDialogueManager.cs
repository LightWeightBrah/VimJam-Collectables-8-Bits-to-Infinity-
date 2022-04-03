using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MyDialogueManager : MonoBehaviour
{
    Player player;

    public bool isDialogueRunning = false;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    Queue<string> sentences;


    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(MyDialogue dialogue)
    {
        isDialogueRunning = true;

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
            
                
        
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //if type sentence is already running it will stop and run a new 
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        isDialogueRunning = false;
        animator.SetBool("IsOpen", false);
        if(player.hasFlower > 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
