using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed            = -1.5f;
    public float background1ScrollSpeed = -1.0f;
    public float background2ScrollSpeed = -0.5f;
    public float background3ScrollSpeed = -0.2f;
    public float background4ScrollSpeed = -0.1f;
    public float skyScrollSpeed         = -0.05f;
    public float backgroundHorizontalLength = 20.48f;

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
