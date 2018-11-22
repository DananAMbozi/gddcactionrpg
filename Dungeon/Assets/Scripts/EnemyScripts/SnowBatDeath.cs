using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBatDeath : MonoBehaviour {

    GameObject player;
    BuffSnowBlindness snowBlindness;

    private void OnDestroy()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            snowBlindness = player.AddComponent<BuffSnowBlindness>();
            player.GetComponent<BuffHandler>().AddBuff(snowBlindness);
        }
    }
}
