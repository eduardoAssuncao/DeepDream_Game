using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick;
    public GameObject CheckPoint;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public float speed;
    public int score;


    /*------------------------*/
    private Rigidbody2D rb;

    /*-----------SUBIR ESCADA-----------*/
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float inputVertical;

    /*------------NextScene-------------*/
    public GameObject PortalScene;
    //public GameObject portal2;
    //public GameObject player;
    public GameObject textPressL;
    public bool podeEntrar = false;

    /*-----morte-----*/
    public Transform Position0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //GetComponent<SpriteRenderer>().sprite = powerUP;
    }

    // Update is called once per frame
    void Update()
    {
        NextScene();
  
        if (joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
        //horizontalMove = joystick.Horizontal * runSpeed;

        float verticalMove = joystick.Vertical;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (verticalMove >= .5f)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (verticalMove <= -.5f)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        /*-------Escada---------*/
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        if (hitInfo.collider != null)
        {
            if (verticalMove >= .5f)
            {
                isClimbing = true;
                //animator.SetTrigger("IsLadder");
            }
        }
        else
        {
            if (horizontalMove >= .2f || horizontalMove <= -.2f)
            {
                isClimbing = false;
                //animator.ResetTrigger("IsLadder");
            }
        }
        if (isClimbing == true && hitInfo.collider != null)
        {
            inputVertical = joystick.Vertical;
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
            animator.SetTrigger("IsLadder");
        }
        else
        {
            animator.ResetTrigger("IsLadder");
            rb.gravityScale = 2.3f;
        }
    }

public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void NextScene()
    {
        if (/*Input.GetKeyDown(KeyCode.C) && */podeEntrar == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    /*-----------Points-------------*/
    public void addscore()
    {
        score = score + 10;
    }

    /*-------------portal-------------*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NextScene")
        {
            podeEntrar = true;
            textPressL.SetActive(true);
        }

        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Position0.transform.position = CheckPoint.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "NextScene")
        {
            podeEntrar = false;
            textPressL.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (score > PlayerPrefs.GetInt("recorde"))
        {
            PlayerPrefs.SetInt("recorde", score);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            this.transform.position = Position0.transform.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
