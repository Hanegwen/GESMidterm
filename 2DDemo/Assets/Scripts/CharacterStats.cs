using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour {

    public bool makeDie = false;

    [SerializeField]
    public float health;

    [SerializeField]
    public float lives = 1;

    [SerializeField]
    public bool dead = false;

    [SerializeField]
    LayerMask EnemyLayer;

    [SerializeField]
    LayerMask EnemyAttackLayer;

    [SerializeField]
    LayerMask PickUpLayer;

    CharacterInput charInfo;

    Animator playerAnimation;

	// Use this for initialization
	void Start ()
    {
        charInfo = GetComponent<CharacterInput>();
        playerAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckLives();
		if(dead)
        {
            Death();
        }

        if(makeDie)
        {
            DiePlease();
        }

        if(!dead)
        {
            playerAnimation.SetBool("Dead", false);
        }
	}

    private void CheckLives()
    {
        if(health <= 0)
        {
            dead = true;
        }
        if(lives <= 0)
        {
            makeDie = true;
        }
    }

    private void DiePlease()
    {
        Death();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Death()
    {

        charInfo.sounds.clip = charInfo.Death;
        charInfo.sounds.Play();
        playerAnimation.SetBool("Dead", true);
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
