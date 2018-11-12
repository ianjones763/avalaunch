using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public GameObject creditsText;
    public Text scoreText;
    public bool gameOver = false;

    public float size;
    public float maxSize = 5f;
    public float minSize = 0.5f;

    // Calculate score based off time played
    private float start_time;
    private int score = 0;

    // Scrolling speed
    public float foregroundXScrollSpeed     = -1.0f;
    public float foregroundYScrollSpeed     = 1.0f;
    public float background1ScrollSpeed     = -2f/3f;
    public float background2ScrollSpeed     = -1f/6f;
    public float background3ScrollSpeed     = -1f/12f;
    public float background4ScrollSpeed     = -1f/24f;
    public float skyScrollSpeed             = -1f/48f;

    // Width of .png sprites for backgrounds = 2048px
    public float backgroundHorizontalLength = 20.48f;


	void Awake () 
    {
        /* Singleton pattern */
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}

    void Start()
    {
        start_time = Time.time;         // To keep track of score
    }


    void Update () 
    {
        /* Restart game on mouse click */
        if (gameOver && Input.GetMouseButton (0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /* Show credits on space bar pressed */
        if (gameOver && Input.GetKeyDown(KeyCode.Space)) 
        {
            creditsText.SetActive(true);
        }

        /* Only update score when game going */
        if (!gameOver) 
        {
            score = (int)((Time.time - start_time) * 2);
            scoreText.text = score.ToString();
        }
    }


    /* Called when player dies */
    public void Died()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
