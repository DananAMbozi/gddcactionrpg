using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Death script attached to the snow bat. Makes the player's screen more difficult to see by adding more snow on screen
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
