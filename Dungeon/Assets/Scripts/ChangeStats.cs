using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStats : MonoBehaviour
{

    public int h, s, d;
    public float ms, atks, st;
    public Sprite Sprite;

    public void Changestats()
    {
        PlayerStats.health = h;
        PlayerStats.atkMS = s;
        PlayerStats.damage = d;
        PlayerStats.movespeed = ms;
        PlayerStats.atkCD = atks;
        PlayerStats.Sprite = Sprite;
        PlayerStats.swingTime = st;
    }
}
