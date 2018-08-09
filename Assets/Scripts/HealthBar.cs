using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private static int maxHealth, health;
    private static GameObject barBackground, bar, barSize;
    private static GameObject parent;

    //constructor
    public HealthBar (GameObject newParent, int newMaxHealth, int newHealth = 0)
    {
        maxHealth = newMaxHealth;
        if (newHealth != 0)
        {
            health = newHealth;
        }
        else
        {
            health = maxHealth;
        }
        parent = newParent;

        SpawnBar();
    }

    // Use this for initialization
    void Start () { 

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnBar ()
    {
        Sprite loadSprite = Resources.Load<Sprite>("HealthBarBackground2");
        barBackground = new GameObject("HealthBarBackground");
        barBackground.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + 1, parent.transform.position.z);
        barBackground.transform.parent = parent.transform;
        SpriteRenderer spriteRend = barBackground.AddComponent<SpriteRenderer>();

        spriteRend.sprite = loadSprite;
        spriteRend.sortingOrder = -1;

        barSize = new GameObject("HealthBarSizer");
        barSize.transform.position = new Vector3(barBackground.transform.position.x - (barBackground.GetComponent<SpriteRenderer>().bounds.size.x / 2), barBackground.transform.position.y, barBackground.transform.position.z);
        barSize.transform.parent = barBackground.transform;

        loadSprite = Resources.Load<Sprite>("HealthBar2");
        bar = new GameObject("HealthBar");
        bar.transform.position = barBackground.transform.position;
        bar.transform.parent = barSize.transform;
        spriteRend = bar.AddComponent<SpriteRenderer>();

        spriteRend.sprite = loadSprite;
    }
}
