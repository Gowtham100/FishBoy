using UnityEngine;
using System.Collections;

public class generateFlowerShots : MonoBehaviour {

	public GameObject shot;
	public float fireRate;

	public float coolDown; //flower enemy must shoot 3 times than cool down for 1 frame
	public float range; //range in which flower reacts to player
	
	private float nextFire;
	private GameObject player;
	private float currentCoolDown;

	private Animator anim;


	void Start () {

		anim = GetComponentInParent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		currentCoolDown = coolDown;

	}

	// Update is called once per frame
	void Update () {

		if (player.GetComponent<Controller3> ().life >= 0) { //if player is allive
			float distance = Vector2.Distance (player.transform.position, this.transform.position); //find distance between player and enemy

			if (Time.time > nextFire && currentCoolDown != 0 && distance < range) {
				anim.SetBool ("isShooting", true);
				currentCoolDown--;
				nextFire = Time.time + fireRate;

				// get the direction of shooting
				Vector3 vectorToTarget = player.transform.position - this.transform.position;
				float angle = (float)Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
				Quaternion direction = Quaternion.AngleAxis (angle, Vector3.forward);

				//instantiate bullet
				Instantiate (shot, this.transform.position, direction);


			} else if (Time.time > nextFire && currentCoolDown == 0) {
				anim.SetBool ("isShooting", false);
				nextFire = Time.time + fireRate;
				currentCoolDown = coolDown;
			} else if (distance < range){
				anim.SetBool ("isShooting", false);
			}

		}


	}
}
