using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    LayerMask BulletLayer;

    [SerializeField]
    float health;

    float DamageTaken;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
