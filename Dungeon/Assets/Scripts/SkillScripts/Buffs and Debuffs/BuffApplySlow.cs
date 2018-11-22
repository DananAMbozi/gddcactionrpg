using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffApplySlow : StatusEffect {

    int slowChance = 100;

    // Update is called once per frame
    void Update()
    {

    }

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
        slowChance += 5;
    }

    public override void TransferBuff(GameObject target)
    {
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
            else
                target.GetComponent<BuffHandler>().AddBuff(target.AddComponent<BuffApplySlow>());
        }
    }
}
