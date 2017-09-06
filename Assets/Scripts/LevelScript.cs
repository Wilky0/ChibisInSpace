using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {
    private bool GameOver = false;
    private float screenLeft;
    private float screenRight;
	// Use this for initialization
	void Start () {
        Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        screenLeft = p.x;
        p = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, Camera.main.nearClipPlane));
        screenRight = p.x;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Left : " + screenLeft + " Right : " + screenRight);
	}

    public void SetGameOver(bool over)
    {
        GameOver = over;
        Debug.Log("GameOver");
    }

    public float GetLeftScreenEdge()
    {
        return screenLeft;
    }

    public float GetRightScreenEdge()
    {
        return screenRight;
    }
}
