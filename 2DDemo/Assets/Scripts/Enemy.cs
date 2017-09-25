using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    LayerMask BulletLayer;

    [SerializeField]
    LayerMask WallLayer;

    [SerializeField]
    float health;

    float DamageTaken;

    EnemyStates enemyStates;

	// Use this for initialization
	void Start ()
    {
        enemyStates = GetComponent<EnemyStates>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Death();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Bullet BulletDamage = other.GetComponent<Bullet>();
            DamageTaken  = BulletDamage.Damage;
            health = health - DamageTaken;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            enemyStates.Flip();
        }
    }

    void Death()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
