using UnityEngine;
using System.Collections;

public class generateFlowerShots : MonoBehaviour {

	public GameObject shot;
	public float fireRate;

	public float coolDown; //flower enemy must shoot 3 times than cool down for 1 frame
	public float range; //range in which flower reacts to player
	
	private float nextFire;
	private GameObject player;


	void Start () {
		coolDown = 3;
		range = 10;
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance (player.transform.position, this.transform.position); //find distance between player and enemy

		if (Time.time > nextFire && coolDown != 0 && distance < range) {
			coolDown--;
			nextFire = Time.time + fireRate;

			// get the direction of shooting
			Vector3 vectorToTarget = player.transform.position - this.transform.position;
			float angle = (float)Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion direction = Quaternion.AngleAxis (angle, Vector3.forward);

			//instantiate bullet
			Instantiate (shot, this.transform.position, direction);


		}else if (Time.time > nextFire && coolDown == 0) {
			nextFire = Time.time + fireRate;
			coolDown = 3;
		}


	}
}
