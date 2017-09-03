using UnityEngine;
using System.Collections;

public class mobScript : MonoBehaviour {
	public float MoveSpeed = 0.05f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3 (0, MoveSpeed, 0);
		if(transform.position.y < -6.0f){
			Destroy(this.gameObject);
		}
	}
}
