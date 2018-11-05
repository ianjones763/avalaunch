using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private float start_time;

	void Start () {
        start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        int score = (int) ((Time.time - start_time)*2) ;
        scoreText.text = score.ToString();
	}
}
