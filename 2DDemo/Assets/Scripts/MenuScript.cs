using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Play1()
    {
        SceneManager.LoadScene("1");
    }

    public void Play2()
    {
        SceneManager.LoadScene("2");
    }

    public void Play3()
    {
        SceneManager.LoadScene("3");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
