using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    [SerializeField]
    public float health;

    [SerializeField]
    public bool dead = false;

    [SerializeField]
    LayerMask EnemyLayer;

    [SerializeField]
    LayerMask EnemyAttackLayer;

    [SerializeField]
    LayerMask PickUpLayer;

    CharacterInput charInfo;

	// Use this for initialization
	void Start ()
    {
        charInfo = GetComponent<CharacterInput>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(dead)
        {
            Death();
        }
	}

    private void Death()
    {

        charInfo.sounds.clip = charInfo.Death;
        charInfo.sounds.Play();
    }

    public float TakeDamage(float Damage)
    {
        health -= Damage;

        return Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        {
            charInfo.sounds.clip = charInfo.PickUp;
            charInfo.sounds.Play();
        }
    }

}
