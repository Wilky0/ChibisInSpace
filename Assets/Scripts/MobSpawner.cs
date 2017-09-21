using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {
	public GameObject MobObject;
    public GameObject LevelController;
    public GameObject playerBase;
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
            float topBound = LevelController.GetComponent<LevelScript>().GetTopOfScreen() - ScreenSideBuffer;
            float bottomBound = LevelController.GetComponent<LevelScript>().GetBottomOfScreen() + ScreenSideBuffer;
            // Gets the playerbase position so it knows where to get to
            Vector3 targetPos = LevelController.GetComponent<LevelScript>().GetBasePosition();

            Vector3 wayPoint = new Vector3(leftBound, Random.Range(topBound, bottomBound), 0f);
            SpawnPos = wayPoint;
            bool inland = true;
            Waypoints = new System.Collections.Generic.List<Vector3>();

            while (wayPoint.x < rightBound)
            {
                if (inland)
                {
                    wayPoint = new Vector3(wayPoint.x + Random.Range(0.4f, 4), wayPoint.y, wayPoint.z);
                    if (wayPoint.x > rightBound)
                    {
                        wayPoint.x = rightBound;
                    }
                }else
                {
                    wayPoint = new Vector3(wayPoint.x, wayPoint.y + Random.Range(-5, 5), wayPoint.z);
                    if (wayPoint.y > topBound)
                    {
                        wayPoint.y = topBound;
                    }else if (wayPoint.y < bottomBound)
                    {
                        wayPoint.y = bottomBound;
                    }
                }
                inland = !inland;

                Waypoints.Add(wayPoint);
            }

            GameObject newBase = Instantiate(playerBase, wayPoint, transform.rotation) as GameObject;
        }
    }

    public Vector3 GetWaypoint(int idx)
    {
        if ((Waypoints != null) & (idx < Waypoints.Count))
        {
            return Waypoints[idx];
        }
        else
        {
            return new Vector3(0f, 0f, 0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		currTimer--;
		if (currTimer < 0)
		{
			GameObject newMob = Instantiate(MobObject, SpawnPos, transform.rotation) as GameObject;
            newMob.GetComponent<mobScript>().SetMobSpawner(this);
			currTimer = timerReset; 
		}
	}
}
