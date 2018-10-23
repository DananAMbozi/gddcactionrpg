using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for generic orbiting movements. Requires a gameObject to orbit around or else will destroy itself
// NOTE: Placement seems to be wonky after 3 orbits (spacing becomes off)
public class OrbitingMovement : MonoBehaviour
{
    private float radius = 0f;  // Possibly obselete, as the radius is manipulated in the Orbit skill class
    private Vector3 offset; // Used mainly when following a moving target. Offsets position
    private float speed = -4f;  // Rotation speed (negative # causes CCW movement)
    private GameObject following = null; // The target, if any
    private bool tracking = false;  // Used with the target. true if following != null
    private Vector3 rotationPoint = new Vector3(0f, 0f, 0f);    // If the orbits should move in place at a specific point, use this
    public SkillOrbits parentSkill = null; // If the orbits were summoned by a specific OrbitSkill, use this for OnDestroy()

    void OnDestroy()
    {
        // Note: Using a destructor doesn't work, as there appears to be a fatal delay
        // GameObject is destroyed elsewhere, OnDestroy() is called to subtract orbit from SkillOrbits list, if exists
        if (parentSkill != null)
            parentSkill.SubtractOrbit();
    }

    public void SetFollowing(GameObject following)
    {
        // Make orbits follow a target. Put null to have them rotate at rotationPoint
        tracking = false;
        if (following != null)
            tracking = true;
        this.following = following;
    }
    public GameObject ShowFollowing()
    {
        // Return who the orbits are following
        return following;
    }

    public void SetPointOfRotation(Vector3 pointOfRotation)
    {
        // Set the point of rotation
        rotationPoint = pointOfRotation;
    }
    public Vector3 ShowPointOfRotation()
    {
        // Show the point of rotation
        return rotationPoint;
    }

    public void SetRadius(float setRadius)
    {
        // Set the radius of the orbits
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

        // Unity circle maths
        if (tracking)
        {
            // Create offset. When target moves, the orbits will follow while maintaining their circular motion
            if (following != null)
            {
                gameObject.transform.position += (following.transform.position - offset);
                offset = following.transform.position;
                rotationPoint = offset; // rotationPoint = following.transform.position
            }
            else
                Destroy(gameObject);    // If there was supposed to be a target but doesn't exist (eg. died), destroy orbits
        }

        // Actual rotation here
        if (radius > 0f)
            gameObject.transform.RotateAround(rotationPoint, Vector3.forward, speed);
    }

    public float GetAngle()
    {
        // Returns the angle of the object relative to what it's following. NOT CURRENTLY USED
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
        // Set new rotation speed of orbits
        speed = newSpeed;
    }

    public float GetSpeed()
    {
        // Returns rotation speed of orbits
        return speed;
    }
}
