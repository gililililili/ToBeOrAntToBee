using UnityEngine;

public class playerMovement : movement
{
    private int movementDirection = 0;
    private bool isJumping = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementDirection = 1;
        }
        else
        {
            movementDirection = 0;
        }
    }

    void FixedUpdate()
    {
        move(movementDirection);
        if(checkGrounded())
        {
            if (isJumping)
            {
                jump();
                isJumping = false;
            }
        }
    }
}
