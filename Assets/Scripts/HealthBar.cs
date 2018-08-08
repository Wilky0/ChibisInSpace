using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private static int maxHealth, health;
    private static GameObject barBackground, bar;
    private static GameObject parent;
    public Texture2D bgTex, barTex;
    public Sprite tstSprite;

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
        barBackground = new GameObject("HealthBarBackground");
        barBackground.transform.parent = parent.transform;
        SpriteRenderer spriteRend = barBackground.AddComponent<SpriteRenderer>();

        //Sprite newSprite = Sprite.Create(bgTex, new Rect(0f, 0f, bgTex.width, bgTex.height), new Vector2(0.5f, 0.5f));
        //newSprite.Create(bgTex, new Rect(0f, 0f, bgTex.width, bgTex.height), new Vector2(0.5f, 0.5f), 128f);

        spriteRend.sprite = tstSprite;
    }
}
