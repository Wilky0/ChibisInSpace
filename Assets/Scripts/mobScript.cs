using UnityEngine;
using System.Collections;

public class mobScript : MonoBehaviour {
	public float MoveSpeed = 0.05f;
    private int health = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (0, MoveSpeed, 0);
		if(transform.position.y < -6.0f){
			Destroy(this.gameObject);
		}
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    public void SetHealth ( int newHealth )
    {
        health = newHealth;
    }

    public void TakeDamage ( int damage )
    {
        health -= damage;
    }
}
