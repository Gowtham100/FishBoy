using UnityEngine;
using System.Collections;

public class Controller3 : MonoBehaviour {

	Animator anim;
	public GameObject bubble;
	public float maxSpeed = 0.0005f;
	public float radius = 1.5f;  //radius of bubble

	public bool enableControl;


	public int life = 50;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();

		enableControl = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (enableControl) {
			float input_x = Input.GetAxisRaw ("Horizontal");
			float input_y = Input.GetAxisRaw ("Vertical");

			bool isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;

			anim.SetBool ("isWalking", isWalking);

			if (isWalking) {
				anim.SetFloat ("X", input_x);
				anim.SetFloat ("Y", input_y);

				transform.position += new Vector3 (input_x, input_y, 0).normalized * Time.deltaTime * maxSpeed;

			}

			//shooting
			bool isShooting = Input.GetButton ("Fire1") || Input.GetButton ("Fire2") || Input.GetButton ("Fire3");
			anim.SetBool ("isShooting", isShooting);
		}
	
	}

	public void playDeadAnim(){
		enableControl = false;
		anim.SetBool ("isDying", true);
	}

	public void initBubble(){
		bubble.transform.localScale = new Vector3(radius,radius,0);
	}

	public void respawn(){
		life = 50;
		initBubble ();
		anim.SetBool ("isDying", false);
		enableControl = true;
	}
	
}
