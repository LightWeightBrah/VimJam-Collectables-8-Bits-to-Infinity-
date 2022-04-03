using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerObject : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            player.hasFlower = 1;
            //save bool hasFlower to player
            PlayerPrefs.SetInt("playerHasFlower", player.hasFlower);
        }
    }
}
