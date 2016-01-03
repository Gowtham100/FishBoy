using UnityEngine;
using System.Collections;

public class BillyShot : MonoBehaviour {

	public float speed;
	public int damage;
	public GameObject player;
	public int bulletCoverage;

	// Use this for initialization
	void Start () {
//		damage = 2;
//		speed = 15;
		GetComponent<Rigidbody2D> ().velocity = transform.right * speed;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance (player.GetComponent<Transform> ().position, this.transform.position);

		if (distance > bulletCoverage) {
			Destroy (gameObject);
		}
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") {
			Destroy (gameObject);
			other.GetComponent<Enemy>().life--;

		}
		
	}

}
