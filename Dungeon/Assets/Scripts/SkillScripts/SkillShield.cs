using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShield : Skills {

    private int maxShields = 3;
    private int shields = 0;
    private float angle;
    private int radius = 2;
    private GameObject shieldObject;
    private GameObject[] shieldTracker;

    public void SetMaxShields(int shieldNumber)
    {
        if (shieldNumber > 1)
        {
            maxShields = shieldNumber;
            shieldTracker = new GameObject[shieldNumber];
            for (int i = 0; i < shieldTracker.Length; i++)
            {
                if (shieldTracker[i] != null)
                    Destroy(shieldTracker[i]);
            }
            shields = 0;

            // arc_length = angle * radius -> angle (degrees) = (2 * PI / shieldNumber)
            // circumference = 2 * PI * radius
            // arcLength = circumference / shieldNumber
            angle = (2 * Mathf.PI) / shieldNumber;
        }
    }

    public int GetMaxShields()
    {
        return maxShields;
    }

    // Use this for initialization
    void Start()
    {
        activeSkill = false;
        maxSkillCooldown = 1f;
        shieldObject = (GameObject)Resources.Load("Shield");
        power = 1f;
        speed = 0f;
        SetMaxShields(maxShields);
        //shieldTracker = new GameObject[maxShields];
    }

    // Update is called once per frame
    void Update()
    {
        skillCooldown -= 1 * Time.deltaTime;
        if (skillCooldown <= 0)
        {
            skillCooldown = maxSkillCooldown;
            if (shields < maxShields)
            {
                shields += 1;
                Activate();
            }
        }
    }

    public override void Activate()
    {
        GameObject shieldClone = Instantiate(shieldObject, gameObject.transform.position, gameObject.transform.rotation);

        if (shields == 1)
        {
            shieldClone.transform.position = gameObject.transform.position + new Vector3(radius, 0f, 0f);
            shieldTracker[0] = shieldClone;
        }
        else
        {
            for (int i = 0; i < shieldTracker.Length; i++)
            {
                if (shieldTracker[i] == null)
                {
                    shieldTracker[i] = shieldClone;
                    if (i - 1 >= 0)
                    {
                        shieldClone.transform.position = gameObject.transform.position + new Vector3(radius, 0f, 0f);
                        shieldClone.transform.RotateAround(gameObject.transform.position, Vector3.forward, shieldTracker[i - 1].GetComponent<ShieldConfig>().GetAngle() + (angle * 180 / Mathf.PI));
                     //   print(i + " " +  shieldClone.transform.position);

                     //   Vector3 positionOffset = shieldTracker[i - 1].transform.position - gameObject.transform.position;
                     //   float posX = positionOffset.x * Mathf.Cos(angle) - positionOffset.y * Mathf.Sin(angle);
                     //  float posY = positionOffset.y * Mathf.Sin(angle) + positionOffset.y * Mathf.Cos(angle);
                     //   shieldTracker[i].transform.position = new Vector3(posX + gameObject.transform.position.x, posY + gameObject.transform.position.y, 0f);
                    }
                    i = shieldTracker.Length;
                }
            }
        }
        shieldClone.GetComponent<ShieldConfig>().following = gameObject;
        shieldClone.GetComponent<ShieldConfig>().CreateFullShield(maxShields == 1);
        shieldClone.GetComponent<ShieldConfig>().parentSkill = this;
    }

    public override void DestroySkill()
    {
        Destroy(this);
    }

    public override string SkillDescription()
    {
        return "Spawns a shield every" + maxSkillCooldown + " seconds. Each shield blocks " + power + " shot(s)";
    }
}
