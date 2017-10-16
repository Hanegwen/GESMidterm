using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour {



    [SerializeField]
    float checkDistance, jumpPower, jumpCount, maxJumps;
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpingHeight;

    [SerializeField]
    bool isOnGround;

    [SerializeField]
    bool facingRight = true;

    [SerializeField]
    Transform jumpCheckTransform;

    [SerializeField]
    LayerMask groundMask;

    Rigidbody2D rb2d;

    [SerializeField]
    GameObject Bullet;

    Animator PlayerAnimation;

    float Move;


    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        
        MovePlayer();
        CheckGound();
        shootObject();
    }

    void MovePlayer()
    {
        
        if (Input.GetButton("Horizontal"))
        {
            Move = Input.GetAxis("Horizontal");
            PlayerAnimation.SetFloat("Speed", Mathf.Abs(Move));
            rb2d.velocity = new Vector2(Move * speed, rb2d.velocity.y);

            if (Move > 0 && !facingRight)
            {
                Flip();
            }
            else if (Move < 0 && facingRight)
            {
                Flip();
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            CharacterJump();
        }
    }

    void shootObject()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y) , this.gameObject.transform.rotation);
        }
    }

    void CheckGound()
    {

        RaycastHit2D hit = Physics2D.Raycast(jumpCheckTransform.transform.position, -Vector2.up, checkDistance, groundMask);
        if (hit.collider == true)
        {
            isOnGround = true;
            

        }
        else
            isOnGround = false;

        PlayerAnimation.SetBool("GroundCheck", isOnGround);
    }


    void CharacterJump()
    {

        if (isOnGround == true)
        {
            jumpCount = 0;
            jumpCount++;
            rb2d.AddForce(Vector2.up * jumpPower);

        }

        else if (isOnGround == false && jumpCount < maxJumps)
        {
            jumpCount++;
            rb2d.AddForce(Vector2.up * jumpPower);

        }

        else
        {
            Debug.Log("Out of Jumps");
        }

    }

    void Flip()
    {

        this.gameObject.transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
}
