using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller3))]

public class gotShot : MonoBehaviour {

	public GameObject bubble;

	//import component
	Controller3 player;
	LvlManager levelmanager;


	// Use this for initialization
	void Start () {
		bubble = this.transform.Find("Bubble").gameObject;
//		Instantiate (bubble, this.transform.position, this.transform.rotation);
//		transform.localScale += new Vector3(0.2F, 0.2F, 0);
//		radius = new int[4]; //radius [0] has smallest radius
//		radius [0] = 0;
//		radius [1] = 2;
//		radius [2] = 3;
//		radius [3] = 4;

		bubble.transform.localScale = new Vector3(4,4,0);

		player = GetComponent<Controller3>();
		levelmanager = FindObjectOfType<LvlManager> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(player.life == 0){
			levelmanager.RespawnPlayer(); //respawn
			player.life = 50;
			bubble.transform.localScale = new Vector3(4,4,0);
		}

		if(other.gameObject.CompareTag ("enemybullet")){
			player.life = player.life - 2;
			bubble.transform.localScale = new Vector3(((player.life - 50F)/100F*5F)+4F,((player.life - 50F)/100F*5F)+4F,0);
		}
	}
}
