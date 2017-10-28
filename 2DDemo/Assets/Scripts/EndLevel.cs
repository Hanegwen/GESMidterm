using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    [SerializeField]
    int levelCount = 1;


    private void Awake()
    {
        DontDestroyOnLoad(this);


    }

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Location();
	}

    void Location()
    {
        if (levelCount == 1)
        {
            this.gameObject.transform.position = new Vector3(323.71f, 43.19519f, 0);
        }

        if (levelCount == 2)
        {
            this.gameObject.transform.position = new Vector3(395.7602f, -59.50225f, 0);
        }

        if (levelCount == 3)
        {
            this.gameObject.transform.position = new Vector3(383.13f, -53.6f, 0);
        }
    }

    void LoadLevel()
    {



        if(levelCount == 3)
        {
            SceneManager.LoadScene("Credits");
        }


        if (levelCount == 2)
        {
            levelCount = 3;
            SceneManager.LoadScene("3");
        }

        if (levelCount == 1)
        {
            levelCount = 2;
            SceneManager.LoadScene("2");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LoadLevel();
        }
    }
}
