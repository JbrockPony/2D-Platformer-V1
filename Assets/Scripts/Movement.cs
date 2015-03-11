using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

    public float speed = 1f;
    public Vector2 jumpForce = new Vector2(100f, 200f);
    TestCollision collisionState;
    bool facingRight;
    Animator anim;
    bool jump;
    bool inAir;
    bool wall;


	// Use this for initialization
	void Start () {
        collisionState = GetComponent<TestCollision>();
        anim = GetComponent<Animator>();
        facingRight = true;
	}

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");

        float realSpeed = collisionState.IsGrounded ? speed * 1.5f : speed;
        transform.position += new Vector3(realSpeed * horizontal * Time.deltaTime, 0f, 0f);
        anim.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal > 0 && !facingRight)
            Flip();
        else if (horizontal < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown("Jump"))
        {
            if (collisionState.IsGrounded)
            {
                rigidbody2D.AddForce(new Vector2(0f, jumpForce.y));
                //anim.SetBool("Jump", true);
                jump = true;
            }
            else if ((!collisionState.IsGrounded && collisionState.IsTouchingWall))
            {
                rigidbody2D.velocity = Vector3.zero;
                float forceX = jumpForce.x;
    
                // Adjust force based of wall position
                if (collisionState.IsWallOnRight)
                    forceX *= -1f;
               
                rigidbody2D.AddForce(new Vector2(forceX, 1.2f * jumpForce.y));
                //anim.SetBool("Jump", true);
                jump = true;
            }
        }

       /* if (jump && !collisionState.IsGrounded)
        {
            inAir = true;
        }

        if (inAir && collisionState.IsGrounded)
        {
            jump = inAir = false;
            anim.SetBool("Jump", jump);
        }*/

        if (Mathf.Abs(rigidbody2D.velocity.y) > 0.01f && !jump)
        {
            jump = true;
            anim.SetBool("Jump", jump);
        }
        else if (jump && Mathf.Abs(rigidbody2D.velocity.y) <= 0.01f)
        {
            jump = false;
            anim.SetBool("Jump", false);
        }

        if (!collisionState.IsGrounded && collisionState.IsTouchingWall != wall)
        {
            wall = collisionState.IsTouchingWall;
            anim.SetBool("Wall", wall);
        }

        if (wall && collisionState.IsGrounded)
        {
            wall = false;
            anim.SetBool("Wall", wall);
        }
	}
}
