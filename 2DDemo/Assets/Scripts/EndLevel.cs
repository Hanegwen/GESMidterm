using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    [SerializeField]
    int levelCount = 3;

    [SerializeField]
    LayerMask PlayerLayer;

    string currentLevel;

	// Use this for initialization
	void Start ()
    {
        currentLevel = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void LoadLevel()
    {
        int currentLevelNum = int.Parse(currentLevel);
        currentLevelNum++;

        if (currentLevelNum > levelCount)
        {
            SceneManager.LoadScene("Credits");
        }
        else
            SceneManager.LoadScene(currentLevelNum);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LoadLevel();
        }
    }
}
