using UnityEngine;
using System.Collections;

public class BillyShot : MonoBehaviour {

	public float speed;
	public int damage;

	// Use this for initialization
	void Start () {
		damage = 2;
		speed = 15;
		GetComponent<Rigidbody2D> ().velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			Destroy (gameObject);

		}
		
	}

}
