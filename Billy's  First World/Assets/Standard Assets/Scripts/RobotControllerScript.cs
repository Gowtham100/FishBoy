using UnityEngine;
using System.Collections;

public class RobotControllerScript : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");
	

		anim.SetFloat ("Speed", Mathf.Abs(move));


		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
	
		if (move > 0 && ! facingRight)
			Flip ();
		else if (move < 0 && facingRight)
		    Flip ();



	}

	void Flip()
	{
		facingRight = ! facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
