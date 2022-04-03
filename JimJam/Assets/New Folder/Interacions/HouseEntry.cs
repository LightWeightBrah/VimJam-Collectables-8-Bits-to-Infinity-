using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEntry : MonoBehaviour
{
    public GameObject enterSign;
    public string SceneToLoadName;

    bool canInteract = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            SceneManager.LoadScene(SceneToLoadName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "cantJumpPlayer")
        {
            enterSign.gameObject.SetActive(true);

            canInteract = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        enterSign.gameObject.SetActive(false);
        canInteract = false;
    }
}
