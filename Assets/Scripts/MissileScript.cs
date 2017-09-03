using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {
	public float speed = 1.0f;
	public Vector3 targetPos;
	public GameObject Explosion;
    private int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Currently fires in z axis, needs to fix for x/y
        transform.right = targetPos - transform.position;

        transform.position += transform.right * speed * Time.deltaTime;
		if (GetDistance(targetPos) < 0.5f)
		{
			explode();
		}
	}
	
	void explode () {
		GameObject newExplosion = Instantiate(Explosion, targetPos, transform.rotation) as GameObject;
        newExplosion.GetComponent<ExplosionScript>().SetDamage(damage);
		Destroy(this.gameObject);
	}
	
	protected float GetDistance(Vector3 target)
    {
        return Mathf.Sqrt((transform.position.x - target.x) * (transform.position.x - target.x) + (transform.position.y - target.y) * (transform.position.y - target.y));
    }

    public void setDamage ( int newDamage )
    {
        damage = newDamage;
    }
}
