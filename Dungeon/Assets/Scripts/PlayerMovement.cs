using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speed;
    public float direction;
    public Vector2 movement;
    private Animator anim;
    private static bool PlayerExists;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        LoadNewPlayer();
//<<<<<<< HEAD
        speed = PlayerStats.movespeed;
        if (speed == 0)
        {
            speed = 1;
        }
//=======
        //speed = 1f;//PlayerStats.movespeed;
//>>>>>>> e406dd28007d45dd390ba28e892c8eed66e76a7a
    }

    void FixedUpdate()
    {
        getInput();

        movePlayer(movement);

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
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDir = moveDir.normalized;
        movement = (speed / 10) * moveDir;

        if (movement.magnitude < (speed / 20)) anim.SetBool("Moving", false);
        else anim.SetBool("Moving", true);
    }

    void movePlayer(Vector2 moveV)
    {
//<<<<<<< HEAD
        rb.position += moveV;
//=======
        rb.position += new Vector2(moveV.x,moveV.y);
        transform.position = rb.position;
//>>>>>>> e406dd28007d45dd390ba28e892c8eed66e76a7a
    }

    void calcAngle()
    {
        direction = Mathf.Atan2(movement.x, movement.y);
        direction = Mathf.Rad2Deg * direction;
    }

    void rotatePlayer()
    {
        if (movement.magnitude < (speed / 50)) return;
        transform.localEulerAngles = new Vector3(0, 0, -direction);
        //transform.eulerAngles = new Vector3(0, 0, -direction);
    }

    void ChangePosition(Vector2 position)
    {
        //transform.position = GameObject.Find("/LevelLayout/StartPoints/SPT").GetComponent<Transform>().position;
        transform.position = position;
    }
}
