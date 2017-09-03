using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {
	public GameObject VisionArea;
	public GameObject missile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FireAt(GameObject target)
    {
        GameObject newMissile = Instantiate(missile, transform.position, Quaternion.LookRotation(target.transform.position - transform.position)) as GameObject;
        newMissile.GetComponent<MissileScript>().targetPos = target.transform.position;
    }

	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "Mob(Clone)")
		{
			FireAt(col.gameObject);
		}
	}
}
