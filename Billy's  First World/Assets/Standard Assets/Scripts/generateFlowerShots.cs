using UnityEngine;
using System.Collections;

public class generateFlowerShots : MonoBehaviour {

	public GameObject shot;
	public float fireRate;

	public float coolDown; //flower enemy must shoot 3 times than cool down for 1 frame

	
	private float nextFire;

	void Start () {
		coolDown = 3;

	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire && coolDown != 0) {
			coolDown--;
			nextFire = Time.time + fireRate;

			// update player every frame
			GameObject player = GameObject.FindGameObjectWithTag ("Player");

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
