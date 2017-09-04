using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour {
    public int health = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            BaseDestroyed();
        }
	}

    void BaseDestroyed ()
    {
        // Insert game over call here!!!
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Mob(Clone)")
        {
            Destroy(col.gameObject);
            health--;
        }
    }
}
