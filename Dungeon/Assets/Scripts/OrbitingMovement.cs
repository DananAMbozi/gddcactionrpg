using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for generic orbiting movements. Requires a gameObject to orbit around or else will destroy itself
public class OrbitingMovement : MonoBehaviour
{
    private float radius = 0f;  //Possibly obselete, as the radius is manipulated in the Orbit skill class
    private Vector3 offset;
    private float speed = -4f;
    private GameObject following = null;
    private bool tracking = false;
    private Vector3 rotationPoint = new Vector3(0f, 0f, 0f);
    public SkillOrbits parentSkill = null;

    ~OrbitingMovement()
    {
        //GameObject is destroyed elsewhere, this destructor is called to subtract orbit from SkillOrbits list, if exists
        if (parentSkill != null)
        {
            parentSkill.SubtractOrbit();
        }
    }

    public void SetFollowing(GameObject following)
    {
        tracking = false;
        if (following != null)
            tracking = true;
        this.following = following;
    }
    public GameObject ShowFollowing()
    {
        return following;
    }

    public void SetPointOfRotation(Vector3 pointOfRotation)
    {
        rotationPoint = pointOfRotation;
    }
    public Vector3 ShowPointOfRotation()
    {
        return rotationPoint;
    }

    public void SetRadius(float setRadius)
    {
        radius = setRadius;
        if (radius <= 0)
            radius = 0;
        else
        {
            if (following != null)
                offset = following.transform.position;
            else
                offset = rotationPoint;
        }
    }
	
	// Update is called once per frame
	void Update () {
        /*
        // Homemade circle maths. Works but doesn't handle float values well (also requires a little set up)
        xOffset += orientation * 0.1f;
        if (Mathf.Abs(xOffset) >= radius)
        {
            xOffset = radius * orientation;
            orientation = -orientation;
        }
        gameObject.transform.position = following.transform.position + new Vector3(xOffset, orientation * Mathf.Sqrt(Mathf.Pow(radius,2) - Mathf.Pow(xOffset,2)), -3f);
        */

        if (tracking)
        {
            //Unity circle maths
            if (following != null)
            {
                gameObject.transform.position += (following.transform.position - offset);
                offset = following.transform.position;
            }
            else
                Destroy(gameObject);
        }

        if (radius > 0f)
            gameObject.transform.RotateAround(following.transform.position, Vector3.forward, speed);
    }

    public float GetAngle()
    {
        //Returns the angle of the object relative to what it's following. Not currently used
        if (following != null)
        {
            if (gameObject.transform.position.y < following.transform.position.y)
                return 360 - Vector3.Angle(gameObject.transform.position, Vector3.right);
            return Vector3.Angle(gameObject.transform.position, Vector3.right);
        }
        return -1f; //If not following, return -1 (error)
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float GetSpeed()
    {
        return speed;
    }
}
