using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    Player player;

    public GameObject pausePanel;
    bool isPausePanelOpened = false;

    public TextMeshProUGUI coins;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPausePanelOpened = !isPausePanelOpened;
            pausePanel.gameObject.SetActive(isPausePanelOpened);
        }

        coins.text = "Coins: " + player.coins;



    }

    public void Resume()
    {
        if(isPausePanelOpened == true)
        {
            pausePanel.gameObject.SetActive(false);
            isPausePanelOpened = false;
        }
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
