using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player.coins++;
            PlayerPrefs.SetInt("CurrentCoins", player.coins);
        }
    }
}
