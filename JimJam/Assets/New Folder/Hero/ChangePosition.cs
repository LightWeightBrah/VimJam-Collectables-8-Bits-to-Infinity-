using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public Vector3 positionAfterFall;

    Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.gameObject.transform.position = positionAfterFall;
            player.health--;
            PlayerPrefs.SetInt("Health", player.health);
        }
    }
}
