using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStats : MonoBehaviour
{

    public int h, s, d;
    public float ms;
    public Sprite Sprite;

    public void Changestats()
    {
        PlayerStats.health = h;
        PlayerStats.atkspeed = s;
        PlayerStats.damage = d;
        PlayerStats.movespeed = ms;
        PlayerStats.Sprite = Sprite;
    }
}
