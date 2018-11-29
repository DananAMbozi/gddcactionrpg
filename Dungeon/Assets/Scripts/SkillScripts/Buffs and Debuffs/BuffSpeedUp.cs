using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpeedUp : StatusEffect
{

    private SpriteRenderer playerSprite;
    private Color changeColour;
    private PlayerMovement playerMovement;
    private float speedBoost = 0.2f;

    private void Awake()
    {
        buffName = "Haste";
        dispellable = true;
        changeColour = new Color(0f, -0.2f, -0.2f, 0f);
    }

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
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();

        buffTimer = maxBuffTimer;

        Activate();
    }

    public override void Activate()
    {
        playerMovement.speed += speedBoost;
        playerSprite.color += changeColour;//+= new Color(1f, 0.8f, 0.8f, 1f);
    }

    public override string buffDescription()
    {
        return buffName + ": Sped up";
    }

    public override void buffDestroy()
    {
        playerSprite.color -= changeColour;//new Color(1f, 1f, 1f, 1f);
        playerMovement.speed -= speedBoost;
        gameObject.GetComponent<BuffHandler>().RemoveBuff(this);
        Destroy(this);
    }

    public override void Stack(StatusEffect sameEffect)
    {
        buffTimer = maxBuffTimer;
    }

    public override void TransferBuff(GameObject target)
    {
    }
}
