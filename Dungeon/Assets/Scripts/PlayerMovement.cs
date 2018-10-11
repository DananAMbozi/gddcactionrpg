using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speed;
    float direction;
    Vector2 movement;
    private Animator anim;
    private static bool PlayerExists;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        LoadNewPlayer();
        speed = 1f;//PlayerStats.movespeed;
    }

    void FixedUpdate()
    {
        getInput();

        movePlayer(movement[0] * speed / 10, movement[1] * speed / 10);

        calcAngle();

        rotatePlayer();
    }

    void LoadNewPlayer()
    {
        if (!PlayerExists)
        {
            PlayerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void getInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(movement.x) < 1 && Mathf.Abs(movement.y) < 1) anim.SetBool("Moving", false);
        else anim.SetBool("Moving", true);
    }

    void movePlayer(float x, float y)
    {
        rb.position += new Vector2(x, y);
        transform.position = rb.position;
    }

    void calcAngle()
    {
        direction = Mathf.Atan2(movement.x, movement.y);
        direction = Mathf.Rad2Deg * direction;
    }

    void rotatePlayer()
    {
        if (Mathf.Abs(movement.x) < 1 && Mathf.Abs(movement.y) < 1) return;
        transform.eulerAngles = new Vector3(0, 0, -direction);
    }

    void ChangePosition(Vector2 position)
    {
        //transform.position = GameObject.Find("/LevelLayout/StartPoints/SPT").GetComponent<Transform>().position;
        transform.position = position;
    }
}
