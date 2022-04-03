using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDialogueTrigger : MonoBehaviour
{
    public MyDialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<MyDialogueManager>().StartDialogue(dialogue);

  
    }
}
