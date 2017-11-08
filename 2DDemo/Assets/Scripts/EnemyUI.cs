using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Enemy enemyStats;

	// Use this for initialization
	void Start ()
    {
        enemyStats = GetComponent<Enemy>();
        healthBar = GetComponentInChildren<Slider>();
        healthBar.maxValue = enemyStats.health;
        healthBar.value = enemyStats.health;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.value = enemyStats.health;
	}
}
