using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToNormalHp : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        PlayerPrefs.SetInt("Health", 5);
    }
}
