using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    public MyDialogue dialogue;
    public MyDialogue dialogueAfterGettingFlower;


    public GameObject listenBox;
    bool overDialogue = false;
    MyDialogueManager mD;
    Player player;


    private void Awake()
    {
        mD = GameObject.FindObjectOfType<MyDialogueManager>();
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cantJumpPlayer")
        {
            if(player.hasFlower == 0)
            {
                listenBox.gameObject.SetActive(true);
            }
            else
            {

            }
            overDialogue = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        listenBox.gameObject.SetActive(false);
        overDialogue = false;
    }

    void Update()
    {
        if (overDialogue && Input.GetKeyDown(KeyCode.E) && !mD.isDialogueRunning)
        {
            if(player.hasFlower == 0)
            {
                mD.StartDialogue(dialogue);
            }
            else if (player.hasFlower > 0)
            {
                mD.StartDialogue(dialogueAfterGettingFlower);
            }
            mD.isDialogueRunning = true;
        }

        else if (overDialogue && Input.GetKeyDown(KeyCode.E) && mD.isDialogueRunning) // Check here that you have a next sentence to display
        {
            mD.DisplayNextSentence();
        }
    }
}