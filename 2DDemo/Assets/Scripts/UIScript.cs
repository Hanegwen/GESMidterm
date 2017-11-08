using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    [SerializeField]
    Text Life;

    [SerializeField]
    Slider health;
    
    CharacterStats charStats;

	// Use this for initialization
	void Start ()
    {
        charStats = FindObjectOfType<CharacterStats>();

        health.maxValue = charStats.health;
        health.value = health.maxValue;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Life.text = "Lives: " + charStats.lives;
        health.value = charStats.health;
	}
}
