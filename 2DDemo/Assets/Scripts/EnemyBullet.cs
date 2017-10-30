using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {


    Rigidbody2D BulletBody;
    BoxCollider2D boxCollider2D;

    [SerializeField]
    float Speed;

    [SerializeField]
    public float Damage;

    [SerializeField]
    LayerMask EnemyLayer;



    // Use this for initialization
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        BulletBody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        BulletBody.velocity = new Vector2(transform.localScale.x * Speed * -1, BulletBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
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
