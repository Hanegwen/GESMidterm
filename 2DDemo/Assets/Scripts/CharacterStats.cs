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

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public float TakeDamage(float Damage)
    {
        health -= Damage;

        return Damage;
    }

}
