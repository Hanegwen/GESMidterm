using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D BulletBody;

    [SerializeField]
    float Speed;

    [SerializeField]
    public float Damage;

	// Use this for initialization
	void Start ()
    {
        BulletBody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(-Time.deltaTime * Speed, 0f, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
