using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {
	public GameObject MobObject;
    public GameObject LevelController;
	public int timerReset = 20;
    public float ScreenSideBuffer = 1f;
    public float ScreenTopBuffer = 1f;
    private Vector3 SpawnPos;
    private System.Collections.Generic.List<Vector3> Waypoints;
	
	private int currTimer = 0;	
	// Use this for initialization
	void Start () {
        GeneratePath();
	}

    void GeneratePath()
    {
        if (LevelController != null)
        {
            // Sets up the bounds for the random gen of waypoints
            float leftBound = LevelController.GetComponent<LevelScript>().GetLeftScreenEdge() + ScreenSideBuffer;
            float rightBound = LevelController.GetComponent<LevelScript>().GetRightScreenEdge() - ScreenSideBuffer;
            float topBound = LevelController.GetComponent<LevelScript>().GetTopOfScreen() + ScreenTopBuffer; 
            // Gets the playerbase position so it knows where to get to
            Vector3 targetPos = LevelController.GetComponent<LevelScript>().GetBasePosition();

            Vector3 wayPoint = new Vector3(Random.Range(leftBound, rightBound), topBound, 0f);
            SpawnPos = wayPoint;    
        }
    }
	
	// Update is called once per frame
	void Update () {
		currTimer--;
		if (currTimer < 0)
		{
			GameObject newMob = Instantiate(MobObject, SpawnPos, transform.rotation) as GameObject;
			currTimer = timerReset; 
		}
	}
}
