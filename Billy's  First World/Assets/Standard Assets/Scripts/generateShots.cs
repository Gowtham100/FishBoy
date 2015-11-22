using UnityEngine;
using System.Collections;

public class generateShots : MonoBehaviour {

	public GameObject shot;
	public GameObject player;
	public float fireRate;
	
	private float nextFire;
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//GameObject player = GameObject.Find(player);

			Instantiate (shot, this.transform.position, this.transform.rotation);

		}
	}
}
