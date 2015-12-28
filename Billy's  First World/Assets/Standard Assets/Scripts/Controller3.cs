using UnityEngine;
using System.Collections;

public class Controller3 : MonoBehaviour {

	Animator anim;
	public float maxSpeed = 0.0005f;


	public int life = 50;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();

	
	}
	
	// Update is called once per frame
	void Update () {

		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");



		bool isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;

		anim.SetBool ("isWalking", isWalking);

		if (isWalking) {
			anim.SetFloat("X", input_x);
			anim.SetFloat("Y", input_y);

			transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime * maxSpeed;

		}



		//shooting
		bool isShooting = Input.GetButton ("Fire1");
		anim.SetBool ("isShooting", isShooting);

 
		//shoot |= Input.GetButtonDown("Fire2");

		if (isShooting)
		{

			anim.SetFloat("X", input_x);
			anim.SetFloat("Y", input_y);
			BillyShooting weapon = GetComponent<BillyShooting>();

		}

	
	}
}
