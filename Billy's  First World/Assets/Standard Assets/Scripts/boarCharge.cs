using UnityEngine;
using System.Collections;

public class boarCharge : MonoBehaviour {

	public float range;
	public string state;
	public float speed;
	public int damage;

	private GameObject player;
	private Animator anim;



	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		state = "Idle";

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player.GetComponent<Controller3> ().life >= 0) { //if player is allive
			Vector2 diff = player.transform.position - this.transform.position;
			float distance = Vector2.Distance (player.transform.position, this.transform.position); //find distance between player and enemy

			if (distance < range) {
				anim.SetFloat ("X", diff.x);
				anim.SetFloat ("Y", diff.y);

				anim.SetTrigger ("isCharging");
				anim.SetBool ("playerDetected", true);
				state = "Charge";
				move ();

			} else {
				anim.SetBool ("playerDetected", false);
			}


		}
	}



	public void move(){
		
		anim.SetTrigger ("isRunning");
		state = "Running";

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run")){
			float step = speed * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, step);

		}
		anim.SetTrigger ("isCharging");
	
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			player.GetComponent<Controller3>().life -= damage;
		}
		
		
	}



}
