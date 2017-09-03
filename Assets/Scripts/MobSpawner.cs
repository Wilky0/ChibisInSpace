using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {
	public GameObject MobObject;
	public int timerReset = 20;
	
	private int currTimer = 0;	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currTimer--;
		if (currTimer < 0)
		{
			GameObject newMob = Instantiate(MobObject, transform.position, transform.rotation) as GameObject;
			currTimer = timerReset; 
		}
	}
}
