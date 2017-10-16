using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCheckPoint : MonoBehaviour {

    [SerializeField]
    LayerMask CheckPointLayer;

    [SerializeField]
    Vector2 checkPointPosition;

    CharacterStats charStats;

	// Use this for initialization
	void Start ()
    {
        charStats = gameObject.GetComponent<CharacterStats>();
        checkPointPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckDeath();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CheckPoint"))
        {
            checkPointPosition = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            
        }
    }

    void CheckDeath()
    {
        if(charStats.dead)
        {
            this.gameObject.transform.position = new Vector3(checkPointPosition.x, checkPointPosition.y, 0);
            charStats.dead = false;
        }
    }
}
