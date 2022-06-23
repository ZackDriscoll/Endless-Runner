using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.0f;
    public float jumpForce = 500.0f;
    public Transform groundPoint;
    public bool isGrounded = false;

    private Rigidbody2D playerRGB2D;

    // Start is called before the first frame update
    void Start()
    {
        playerRGB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    //Function for player input
    void PlayerInput()
    {
        //Controls Horizontal movement
        float xMovement = Input.GetAxis("Horizontal") * movementSpeed;
        playerRGB2D.velocity = new Vector2(xMovement, playerRGB2D.velocity.y);
        if (xMovement > 0)
        {
            //animator.Play("PlayerWalk");
        }
        else
        {
            //animator.Play("PlayerIdle");
        }

        //Detect if the player is on the ground
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.1f);
        if (hitInfo.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Jump with spacebar
        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded) 
            || (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) 
            || (Input.GetKeyDown(KeyCode.W) && isGrounded))
        {
            Debug.Log("Jump");
            playerRGB2D.AddForce(Vector2.up * jumpForce);
        }
    }
}

