using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {
	public GameObject MobObject;
    public GameObject LevelController;
    public GameObject playerBase;
    public GameObject WaterSprite;
	public int timerReset = 20;
    public float ScreenSideBuffer = 1f;
    public float ScreenTopBuffer = 1f;
    private Vector3 SpawnPos;
    private System.Collections.Generic.List<Vector3> Waypoints;
    private System.Collections.Generic.List<GameObject> toCleanUp;

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

            // Creates the spawn point randomly across the left side of screen
            Vector3 wayPoint = new Vector3(leftBound, Random.Range(topBound, bottomBound), 0f);
            SpawnPos = wayPoint;
            bool inland = true;
            Waypoints = new System.Collections.Generic.List<Vector3>();
            toCleanUp = new System.Collections.Generic.List<GameObject>();
            Vector3 LastWaypoint;

            // Loop untill at the end of the screen
            while (wayPoint.x < rightBound)
            {
                // if inland then the next waypoint will be in the x direction
                if (inland)
                {
                    wayPoint = new Vector3(wayPoint.x + Random.Range(2, 5), wayPoint.y, wayPoint.z);
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

                // Draw the water path - will need to be replaced with good looking segments
                if (Waypoints.Count > 0)
                {
                    LastWaypoint = Waypoints[Waypoints.Count - 1];
                }else
                {
                    LastWaypoint = SpawnPos;
                }

                GameObject path = Instantiate(WaterSprite) as GameObject;
                Strech(path, LastWaypoint, wayPoint, false);
                toCleanUp.Add(path);

                // add the new waypoint to a list of waypoints
                Waypoints.Add(wayPoint);
            }

            // create the player's base at the end of the generated path
            GameObject newBase = Instantiate(playerBase, wayPoint, transform.rotation) as GameObject;
        }
    }

    public void Strech(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ)
    {
        Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        _sprite.transform.position = centerPos;
        Vector3 direction = _finalPosition - _initialPosition;
        direction = Vector3.Normalize(direction);
        _sprite.transform.right = direction;
        if (_mirrorZ) _sprite.transform.right *= -1f;
        Vector3 scale = new Vector3(1, 0.2f, 0.2f);
        scale.x = (Vector3.Distance(_initialPosition, _finalPosition) * 0.20f);
        _sprite.transform.localScale = scale;
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
