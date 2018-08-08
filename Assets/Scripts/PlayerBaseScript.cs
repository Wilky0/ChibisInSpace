using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour {
    public int health = 50;
    public GameObject LevelController;
    HealthBar healthBar;
	// Use this for initialization
	void Start () {
        healthBar = new HealthBar(this.gameObject, health);

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
        if (LevelController != null)
        {
            LevelController.GetComponent<LevelScript>().SetGameOver(true);
        }
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
