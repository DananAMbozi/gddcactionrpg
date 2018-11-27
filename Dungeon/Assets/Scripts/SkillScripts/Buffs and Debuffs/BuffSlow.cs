using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the slow debuff. Slows player, object, and projectile movements assuming they have the BuffHandler script attached
public class BuffSlow : StatusEffect {

    bool targetPlayer;  // If it targets a player/enemy (true) or a projectile (false)
    Color gameObjectColor;
    bool instantiated = false; // Used for TransferEffects(). Instantiated = true when attaching this script to an object instantiated by this gameObject
    float instanceTimer = 0.03f;    // Arbitrary delay when transferring effects due to how velocity is handled

    private void Update()
    {
        buffTimer -= Time.deltaTime;

        // Does not apply slow effect right away due to how AddForce works
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

        // Reduce player/enemy/projectile speed by 70%. Note that this does not work on projectiles if they change their speed (will need to fix)
        if (gameObject.GetComponent<PlayerMovement>() != null)
            gameObject.GetComponent<PlayerMovement>().speed *= 0.3f;
        else if (gameObject.GetComponent<ChasePlayer>() != null)
            gameObject.GetComponent<ChasePlayer>().boxSpeed *= 0.3f;
        else if (gameObject.GetComponent<Rigidbody2D>() != null)
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
        // Return speed back to original
        if (gameObject.GetComponent<PlayerMovement>() != null)
            gameObject.GetComponent<PlayerMovement>().speed /= 0.3f;
        else if (gameObject.GetComponent<ChasePlayer>() != null)
            gameObject.GetComponent<ChasePlayer>().boxSpeed /= 0.3f;
        else if (gameObject.GetComponent<Rigidbody2D>() != null)
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
        // On override, just renew the slow effect for whatever the newest applied buff duration is
        maxBuffTimer = sameEffect.GetMaxBuffTimer();
        buffTimer = maxBuffTimer;
    }

    public override void TransferBuff(GameObject target)
    {
        // Attach slow debuff to whatever this object instantiates if the instantiated object has a BuffHandler component
        if (target.GetComponent<BuffHandler>() != null)
        {
            BuffSlow transferSlow = target.AddComponent<BuffSlow>();
            transferSlow.Instantiated(true);
            transferSlow.SetBuffTimer(GetMaxBuffTimer());
            target.GetComponent<BuffHandler>().AddBuff(transferSlow);
        }
    }
}
