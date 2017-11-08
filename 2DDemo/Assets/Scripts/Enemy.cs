using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    LayerMask BulletLayer;

    [SerializeField]
    LayerMask WallLayer;

    [SerializeField]
    public float health;

    float DamageTaken;

    EnemyStates enemyStates;

    Animator enemyAnimator;

	// Use this for initialization
	void Start ()
    {
        enemyStates = GetComponent<EnemyStates>();
        enemyAnimator = GetComponent<Animator>();
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

        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            enemyStates.Flip();
        }

    }


    void Death()
    {
        if (health <= 0)
        {
            enemyAnimator.SetBool("Dead", true);
            Destroy(this.gameObject, 1);
        }
    }
}
