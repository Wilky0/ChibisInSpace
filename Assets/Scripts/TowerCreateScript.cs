using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreateScript : MonoBehaviour {
    public GameObject Tower;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            GameObject newTower = Instantiate(Tower, pz, new Quaternion(0,0,0,0)) as GameObject;
        }
    }
}
