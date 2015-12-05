using UnityEngine;
using System.Collections;

public class generateShots : MonoBehaviour {

	public GameObject shot;
	public float fireRate;
	
	private float nextFire;
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			// update player every frame
			GameObject player = GameObject.FindGameObjectWithTag("Player");

			// get the direction of shooting
			Vector3 vectorToTarget = player.transform.position - this.transform.position;
			float angle = (float) Mathf.Atan2(vectorToTarget.y, vectorToTarget.x)* Mathf.Rad2Deg;
			Quaternion direction = Quaternion.AngleAxis(angle, Vector3.forward);

			//instantiate bullet
			Instantiate (shot, this.transform.position, direction);

		}
	}
}
