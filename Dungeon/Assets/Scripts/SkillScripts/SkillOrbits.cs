using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillOrbits : Skills {

    protected int maxOrbits = 1;
    protected int orbits = 0;
    protected float angle;
    protected float radius = 2f;
    protected GameObject orbitObject;
    protected GameObject[] orbitTracker;

    public override void Activate()
    {
        GameObject orbitClone = Instantiate(orbitObject, gameObject.transform.position, gameObject.transform.rotation);

        if (maxOrbits > 1)
        {
            if (orbits == 1)
            {
                orbitClone.transform.position = gameObject.transform.position + new Vector3(radius, 0f, 0f);
                orbitTracker[0] = orbitClone;
            }
            else
            {
                for (int i = 0; i < orbitTracker.Length; i++)
                {
                    if (orbitTracker[i] == null)
                    {
                        orbitTracker[i] = orbitClone;
                        if (i - 1 >= 0) //Check the position of the orbit behind it and base its position on that
                        {
                            // Unity's rotation
                            // orbitClone.transform.position = gameObject.transform.position + new Vector3(radius, 0f, 0f);
                            // orbitClone.transform.RotateAround(gameObject.transform.position, Vector3.forward, orbitTracker[i - 1].GetComponent<ShieldConfig>().GetAngle() + (angle * 180 / Mathf.PI));

                            // Homemade rotation. Refer to rotation matrix (2D)
                            Vector3 positionOffset = orbitTracker[i - 1].transform.position - gameObject.transform.position;
                            float posX = positionOffset.x * Mathf.Cos(angle) + positionOffset.y * Mathf.Sin(angle);
                            float posY = positionOffset.y * Mathf.Cos(angle) - positionOffset.x * Mathf.Sin(angle);
                            orbitTracker[i].transform.position = new Vector3(posX + gameObject.transform.position.x, posY + gameObject.transform.position.y, 0f);
                        }
                        else // If the shield to be replaced is in the 0th position, need to check if an orbit exists first
                        {
                            bool referenceFound = false;    // If there exists an orbit, referenceFound = true;
                            int counter = orbitTracker.Length - 1;  // Count backwards from maxOrbits to 1
                            while((!referenceFound) && (counter > 0))
                            {
                                if (orbitTracker[counter] != null)
                                    referenceFound = true;
                                else
                                    counter -= 1;
                            }
                            if (referenceFound) // Set rotation relative to the orbit found (same formula as above). Can probably be merged with code above
                            {
                                Vector3 positionOffset = orbitTracker[counter].transform.position - gameObject.transform.position;
                                float posX = positionOffset.x * Mathf.Cos(angle * (maxOrbits - counter)) + positionOffset.y * Mathf.Sin(angle * (maxOrbits - counter));
                                float posY = positionOffset.y * Mathf.Cos(angle * (maxOrbits - counter)) - positionOffset.x * Mathf.Sin(angle * (maxOrbits - counter));
                                orbitTracker[0].transform.position = new Vector3(posX + gameObject.transform.position.x, posY + gameObject.transform.position.y, 0f);
                            }
                        }
                        i = orbitTracker.Length;
                    }
                }
            }
        }
        orbitClone.GetComponent<OrbitingMovement>().SetFollowing(gameObject);
        orbitClone.GetComponent<OrbitingMovement>().SetRadius(radius);
        orbitClone.GetComponent<OrbitingMovement>().parentSkill = this;
        orbitClone.GetComponent<OrbitingMovement>().SetSpeed(speed);
    }

    public void SetMaxOrbits(int orbitNumber)
    {
        maxOrbits = orbitNumber;
        if (maxOrbits <= 1)
            radius = 0f;
        orbitTracker = new GameObject[orbitNumber];
        for (int i = 0; i < orbitTracker.Length; i++)
        {
            if (orbitTracker[i] != null)
                Destroy(orbitTracker[i]);
        }
        orbits = 0;

        // arc_length = angle * radius -> angle (degrees) = (2 * PI / shieldNumber)
        // circumference = 2 * PI * radius
        // arcLength = circumference / shieldNumber
        angle = (2 * Mathf.PI) / orbitNumber;
    }

    public int GetMaxOrbits()
    {
        return maxOrbits;
    }

    public int GetOrbits()
    {
        return orbits;
    }

    public void SubtractOrbit()
    {
        orbits -= 1;
    }

    public void AddOrbit()
    {
        orbits += 1;
    }
}