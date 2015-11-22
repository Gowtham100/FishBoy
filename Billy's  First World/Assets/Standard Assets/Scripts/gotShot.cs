using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2))]

public class gotShot : MonoBehaviour {

	public int[] radius;

	public GameObject bubble;

	//import component
	Controller2 player;
	LvlManager levelmanager;


	// Use this for initialization
	void Start () {
		bubble = this.transform.Find("Bubble").gameObject;
//		Instantiate (bubble, this.transform.position, this.transform.rotation);
//		transform.localScale += new Vector3(0.2F, 0.2F, 0);
		radius = new int[3]; //radius [0] has smallest radius
		radius [0] = 0;
		radius [1] = 2;
		radius [2] = 3;

		player = GetComponent<Controller2>();
		levelmanager = FindObjectOfType<LvlManager> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.CompareTag ("enemybullet")){
			if(player.life == 1){
				levelmanager.RespawnPlayer(); //respawn
			} else{
				bubble.transform.localScale = new Vector3(radius[player.life-2],radius[player.life-2],0);
				player.life--;
			}

		}
	}
}
