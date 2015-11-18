using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	float speed; // the bullet speed
	Vector2 _direction; // the direction of the bullet
	bool isReady; // to know when the bullet function is set

	// set default values in awake
	void Awake(){
		speed = 5f;
		isReady = false;
	}

	// Use this for initialization
	void Start () {
	
	} 

	//Function to set the bullet's direction
	public void SetDirection(Vector2 direction){
		// set the direction normalized, to get an unit vector
		_direction = direction.normalized;
		isReady = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (isReady) {
			//get the bullets current position
			Vector2 position = transform.position;

			//compute the bullets new position
			position += _direction * speed * Time.deltaTime;

			//update bullets position
			transform.position = position;

			//removing bullet from the game

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

			//if out the screen distroy
			if ((transform.position.x < min.x) || (transform.position.x > min.x) ||
			    (transform.position.y < min.y) || (transform.position.y < min.y))
			{
				Destroy(gameObject);
			}

		}
	
	}
}
