using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingForeground: MonoBehaviour {

    private Rigidbody2D rb2d;

	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.foregroundScrollSpeed, 0);
	}

	void Update () 
    {
        rb2d.velocity = new Vector2(GameControl.instance.foregroundScrollSpeed, 0);
        if (GameControl.instance.gameOver) rb2d.velocity = Vector2.zero;
    }
}
