using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpeedUp : StatusEffect
{

    private SpriteRenderer playerSprite;
    private PlayerMovement playerMovement;
    private float speedBoost = 0.2f;


    void Update()
    {
        buffTimer -= 1 * Time.deltaTime;

        if (buffTimer <= 0)
            buffDestroy();
    }

    public void SetSpeedUp(float amt)
    {
        speedBoost = amt;
    }

    public override void Init()
    {
        dispellable = true;
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();

        buffTimer = maxBuffTimer;

        Activate();
    }

    public override void Activate()
    {
        playerMovement.speed += speedBoost;
        playerSprite.color = new Color(1f, 0.8f, 0.8f, 1f);
    }

    public override string buffDescription()
    {
        return buffName + ": Sped up";
    }

    public override void buffDestroy()
    {
        playerSprite.color = new Color(1f, 1f, 1f, 1f);
        playerMovement.speed -= speedBoost;
        Destroy(this);
    }

    public override void Stack()
    {
        //Currently unused
        buffTimer = maxBuffTimer;
    }
}
