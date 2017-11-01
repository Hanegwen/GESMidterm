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

	// Use this for initialization
	void Start ()
    {
        charInfo = GetComponent<CharacterInput>();
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
	}

    private void CheckLives()
    {
        if(lives <= 0)
        {
            makeDie = true;
        }
    }

    private void DiePlease()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
