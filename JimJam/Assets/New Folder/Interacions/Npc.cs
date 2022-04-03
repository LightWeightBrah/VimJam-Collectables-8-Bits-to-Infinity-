using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public MyDialogue dialogue;
    public MyDialogue dialogueWhenHaveGold;
    public int canDoubleJump = 0;
    public MyDialogue dialogueAfterUnlocked;

    public GameObject listenBox;
    bool overDialogue = false;
    MyDialogueManager mD;
    Player player;


    private void Awake()
    {
        mD = GameObject.FindObjectOfType<MyDialogueManager>();
        player = GameObject.FindObjectOfType<Player>();
        canDoubleJump = PlayerPrefs.GetInt("canDoubleJump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            listenBox.gameObject.SetActive(true);
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
            if (player.coins >= 25 && canDoubleJump == 0)
            {
                mD.StartDialogue(dialogueWhenHaveGold);
                canDoubleJump ++;
                PlayerPrefs.SetInt("canDoubleJump", canDoubleJump);
                player.extraJumpsValue = 2;
                PlayerPrefs.SetInt("extraJumpsValue", player.extraJumpsValue);
            }
            else if(player.coins < 25 && canDoubleJump == 0)
            {
                mD.StartDialogue(dialogue);
            }
            else if(canDoubleJump == 1)
            {
                mD.StartDialogue(dialogueAfterUnlocked);
            }
            mD.isDialogueRunning = true;
        }

        else if (overDialogue && Input.GetKeyDown(KeyCode.E) && mD.isDialogueRunning) // Check here that you have a next sentence to display
        {
            mD.DisplayNextSentence();
        }
    }
}