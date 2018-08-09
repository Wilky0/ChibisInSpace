using UnityEngine;
using System.Collections;

public class mobScript : MonoBehaviour {
	public float MoveSpeed = 0.05f;
    private int health = 10;
    private MobSpawner spawner;
    private Vector3 target;
    private int targetIdx = 0;
    private HealthBar healthBar;

	// Use this for initialization
	void Start () {
        if (spawner != null)
        { 
            target = spawner.GetWaypoint(targetIdx);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position -= new Vector3 (0, MoveSpeed, 0);
        //if(transform.position.y < -6.0f){
        //	Destroy(this.gameObject);
        //}
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed);

        if (Vector3.Distance(transform.position,target) < 0.1f)
        {
            if (spawner != null)
            {
                targetIdx++;
                target = spawner.GetWaypoint(targetIdx);
            }
        }
	}

    public void SetMobSpawner(MobSpawner newSpawner)
    {
        spawner = newSpawner;
    }

    public void SetHealth ( int newHealth )
    {
        health = newHealth;
    }

    public void TakeDamage ( int damage )
    {
        if (healthBar == null)
        {
            healthBar = new HealthBar(this.gameObject, health);
        }

        health -= damage;

        healthBar.SetHealth(health);

    }
}
