using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {


    Rigidbody2D BulletBody;

    [SerializeField]
    float Speed;

    [SerializeField]
    public float Damage;

    public bool destroy;

    // Use this for initialization
    void Start()
    {
        BulletBody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        

        if(destroy)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        BulletBody.velocity = new Vector2(transform.localScale.x * Speed * -1, BulletBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterStats>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
