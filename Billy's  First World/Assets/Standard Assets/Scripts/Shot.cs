using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed;
	public int damage;

	private Controller3 player;


	// Use this for initialization
	// this method is executed when we instantiated the laser object
	void Start () {
		damage = 2;
		speed = 15;
		// transform.forward is to make it move forward (along x axis in this case)
		GetComponent<Rigidbody2D> ().velocity = transform.right * speed;

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller3>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			Destroy (gameObject);
			player.life -= damage;
		}
			
	}


}
