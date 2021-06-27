using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump = true;
    int groundMask = 1 << 8; // this is a “bitshift”

    bool isIdle;
    bool isLeft;
    int isIdleKey = Animator.StringToHash("isIdle");
    int isJumpKey = Animator.StringToHash("isJump");

    // Start is called before the first frame update
    private void Update()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool(isIdleKey, isIdle);
        animator.SetBool(isJumpKey, !canJump);

        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.flipX = isLeft;
    }

    void FixedUpdate()
    {
        isIdle = true;
        // the new velocity to apply to the character
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        // move to the left
        if (Input.GetKey(KeyCode.A))
        {
            physicsVelocity.x -= 10;
            isIdle = false;
            isLeft = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            physicsVelocity.x = 10;
            isIdle = false;
            isLeft = false;
        }
        // implement moving to the right for the D key
        // this allows the player to jump, but only if canJump is true
        if (Input.GetKey(KeyCode.W))
        {
            if (canJump == true)
            {
                r.velocity = new Vector2(physicsVelocity.x, 10);
                canJump = false;
            }
        }

        if (Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y), -Vector2.up, 2.5f, groundMask))
        {
            canJump = true;
        }
        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(physicsVelocity.x,r.velocity.y);
        // Update is called once per frame
    }
}
