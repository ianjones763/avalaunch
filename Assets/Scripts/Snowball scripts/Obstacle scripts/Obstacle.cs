using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "snowball") 
        {
            if (gameObject.tag == "igloo")
            {
                breakIgloo();
            }
            GameControl.instance.Died();
        }
    }

    private void breakIgloo()
    {
        Debug.Log("break igloo");
    }
}
