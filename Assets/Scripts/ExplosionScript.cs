using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {
    public float ExpandSpeed = 1f;
    public float MaxScale = 0.5f;
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newScale;
        newScale = transform.localScale;
        newScale.x = newScale.x + ExpandSpeed * Time.deltaTime;
        newScale.y = newScale.y + ExpandSpeed * Time.deltaTime;
        transform.localScale = newScale;

        if (transform.localScale.x > MaxScale)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Mob(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}
