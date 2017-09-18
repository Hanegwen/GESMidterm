using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpingHeight;

    Rigidbody2D PlayerBody;

	// Use this for initialization
	void Start ()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
	}

    void MovePlayer()
    {
        if (Input.GetButton("Right"))
        {
            PlayerBody.AddForce(transform.right * speed);
        }

        if (Input.GetButton("Left"))
        {
            PlayerBody.AddForce(transform.right * speed * -1);
        }

        if (Input.GetButton("Jump"))
        {
            PlayerBody.AddForce(transform.up * jumpingHeight);
        }

        else
        {
            PlayerBody.AddForce(transform.right * 0);
            PlayerBody.AddForce(transform.up * 0);
        }
    }
}
