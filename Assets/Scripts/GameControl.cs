using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;


    private int score = 0;

	void Awake () 
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}
	

	void Update () 
    {
        if (gameOver && Input.GetMouseButton (0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		
	}


    public void Died()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
