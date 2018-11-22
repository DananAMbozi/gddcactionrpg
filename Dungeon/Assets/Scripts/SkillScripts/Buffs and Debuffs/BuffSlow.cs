using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSlow : StatusEffect {

    bool targetPlayer;
    Color gameObjectColor;
    bool instantiated = false;
    float instanceTimer = 0.05f;

    private void Update()
    {
        buffTimer -= Time.deltaTime;

        if(instantiated)
        {
            instanceTimer -= Time.deltaTime;
            if (instanceTimer <= 0)
            {
                instantiated = false;
                Activate();
            }
        }

        if (buffTimer <= 0)
            buffDestroy();
    }

    public override void Activate()
    {
        gameObjectColor = new Color(-0.2f, -0.2f, 0f, 0f);
        buff = false;

        if ((gameObject.tag == "Player") || (gameObject.tag == "Enemy") || (gameObject.tag == "Boss") || (gameObject.tag == "GunEnemy"))
            targetPlayer = true;
        else
            targetPlayer = false;


        if (targetPlayer)
        {
            if (gameObject.GetComponent<PlayerMovement>() != null)
                gameObject.GetComponent<PlayerMovement>().speed *= 0.3f;
            else if (gameObject.GetComponent<ChasePlayer>() != null)
                gameObject.GetComponent<ChasePlayer>().boxSpeed *= 0.3f;
        }
        else
            gameObject.GetComponent<Rigidbody2D>().velocity *= 0.3f;

        gameObject.GetComponent<SpriteRenderer>().color += gameObjectColor;
    }

    public void Instantiated(bool isInstantiated)
    {
        instantiated = isInstantiated;
    }

    public override string buffDescription()
    {
        return buffName + ": Slowed";
    }

    public override void buffDestroy()
    {
        if (targetPlayer)
        {
            if (gameObject.GetComponent<PlayerMovement>() != null)
                gameObject.GetComponent<PlayerMovement>().speed /= 0.3f;
            else if (gameObject.GetComponent<ChasePlayer>() != null)
                gameObject.GetComponent<ChasePlayer>().boxSpeed /= 0.3f;
        }
        else
            gameObject.GetComponent<Rigidbody2D>().velocity /= 0.3f;

        gameObject.GetComponent<SpriteRenderer>().color -= gameObjectColor;
        gameObject.GetComponent<BuffHandler>().RemoveBuff(this);
        Destroy(this);
    }

    public override void Init()
    {
        if(!instantiated)
            Activate();
    }

    public override void Stack(StatusEffect sameEffect)
    {
    }

    public override void TransferBuff(GameObject target)
    {
        if (target.GetComponent<BuffHandler>() != null)
        {
            BuffSlow transferSlow = target.AddComponent<BuffSlow>();
            transferSlow.Instantiated(true);
            transferSlow.SetBuffTimer(GetMaxBuffTimer());
            target.GetComponent<BuffHandler>().AddBuff(transferSlow);
        }
    }
}
