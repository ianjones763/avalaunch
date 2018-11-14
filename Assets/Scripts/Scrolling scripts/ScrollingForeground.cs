using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingForeground: MonoBehaviour {

    private Rigidbody2D rb2d;

	void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.foregroundXScrollSpeed, GameControl.instance.foregroundYScrollSpeed);
	}

	void Update() 
    {
        /* Compute perpindicular vector to the normal (basically compute slope of terrain) */
        Vector2 perp = new Vector2(-GameControl.instance.norm.y, GameControl.instance.norm.x);
        Vector2 midAir = new Vector2(0f, 0f); // Player is midair, just scroll x direction

        float xVel = GameControl.instance.norm != midAir ? perp.normalized.x : -1.0f;
        float yVel = GameControl.instance.norm != midAir ? perp.normalized.y : 0f;

        /* Scroll speed computed from the normalized vector */
        rb2d.velocity = new Vector2(xVel * GameControl.instance.scrollSpeed, yVel * GameControl.instance.scrollSpeed);
        //rb2d.velocity = new Vector2(GameControl.instance.foregroundXScrollSpeed, GameControl.instance.foregroundYScrollSpeed);

        /* Stop scrolling on game over */
        if (GameControl.instance.gameOver) rb2d.velocity = Vector2.zero;
    }
}
