using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TabsSwitcher : MonoBehaviour
{
    public GameObject credits;
    public GameObject mainMenu;


    public void QuitTheGame()
    {
        PlayerPrefs.SetInt("extraJumpsValue", 1);
        PlayerPrefs.SetInt("canDoubleJump", 0);
        PlayerPrefs.SetInt("playerHasFlower", 0);
        PlayerPrefs.SetInt("Health", 5);
        PlayerPrefs.SetInt("CurrentCoins", 0);

        Application.Quit();
        Debug.Log("Apllication quits");
    }

    public void GoToMainMenu()
    {
        PlayerPrefs.SetInt("extraJumpsValue", 1);
        PlayerPrefs.SetInt("canDoubleJump", 0);
        PlayerPrefs.SetInt("playerHasFlower", 0);
        PlayerPrefs.SetInt("Health", 5);
        PlayerPrefs.SetInt("CurrentCoins", 0);


        SceneManager.LoadScene("MainMenu");
        Debug.Log("Goes to Main Menu");

    }

    public void PlayGameFromGameOver()
    {
        PlayerPrefs.SetInt("extraJumpsValue",1);
        PlayerPrefs.SetInt("canDoubleJump",0);
        PlayerPrefs.SetInt("playerHasFlower", 0);
        PlayerPrefs.SetInt("Health", 5);
        PlayerPrefs.SetInt("CurrentCoins", 0);



        SceneManager.LoadScene("House 1");
    }


    public void CloseCredits()
    {
        credits.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void OpenCredits()
    {
        credits.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }
}
