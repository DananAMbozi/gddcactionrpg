using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Passive effect that can apply slow to bullets. Testing purposes. Currently not in game
public class BuffApplySlow : StatusEffect {

    int slowChance = 20;

    public override void Activate()
    {
    }

    public override string buffDescription()
    {
        return buffName + ": Attacks have a chance of slowing foes";
    }

    public override void buffDestroy()
    {
        gameObject.GetComponent<BuffHandler>().RemoveBuff(this);
        Destroy(this);
    }

    public override void Init()
    {
        buffName = "Apply Slow";

        stackable = false;
        dispellable = false;
        buff = true;
        slowChance = 100;
    }

    public override void Stack(StatusEffect sameEffect)
    {
        // Untested. Arbitrary value
        slowChance += 0;
    }

    public override void TransferBuff(GameObject target)
    {
        // Whoever the projectile hits will have a buffslow applied to it
        if (target.GetComponent<BuffHandler>() != null)
        {
            if ((target.tag == "Player") || (target.tag == "Enemy") || (target.tag == "GunEnemy") || (target.tag == "Boss"))
            {
                if (Random.Range(0, 100) < slowChance)
                {
                    BuffSlow slow = target.AddComponent<BuffSlow>();
                    slow.SetBuffTimer(5f);
                    target.GetComponent<BuffHandler>().AddBuff(slow);
                }
            }
            else // When instantiating an object (likely projectile), give this buff to it. Untested on summoning enemies
                target.GetComponent<BuffHandler>().AddBuff(target.AddComponent<BuffApplySlow>());
        }
    }
}
