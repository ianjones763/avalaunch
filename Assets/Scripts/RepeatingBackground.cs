using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	void Update () 
    {
        if (transform.position.x < -GameControl.instance.backgroundHorizontalLength)
        {
            RepositionBackground();
        }
	}

    private void RepositionBackground() 
    {
        Vector2 backgroundOffset = new Vector2(GameControl.instance.backgroundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + backgroundOffset;
    }
}
