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
    Transform jumpCheckTransform;

    [SerializeField]
    LayerMask groundMask;

    Rigidbody2D rb2d;

    [SerializeField]
    GameObject Bullet;


    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
            Vector3 position = this.transform.position;
            position.x = position.x - (Input.GetAxis("Horizontal") * speed);
            this.transform.position = position;
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
}
