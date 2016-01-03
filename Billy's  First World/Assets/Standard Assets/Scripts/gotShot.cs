using UnityEngine;
using System.Collections;

//This script reduce bubble size according to the life of the player

[RequireComponent(typeof(Controller3))]
[RequireComponent(typeof(Shot))]

public class gotShot : MonoBehaviour {

	public GameObject bubble;

	//import component
	Controller3 player;
	LvlManager levelmanager;


	// Use this for initialization
	void Start () {
		bubble = this.transform.Find("Bubble").gameObject;

		//init bubble with radius 2
		bubble.transform.localScale = new Vector3(2,2,0);

		player = GetComponent<Controller3>();
		levelmanager = FindObjectOfType<LvlManager> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(player.life <= 0){
			levelmanager.RespawnPlayer(); //respawn
			player.life = 50;
			bubble.transform.localScale = new Vector3(2,2,0);
		}

		if(other.tag == "enemybullet"){
			bubble.transform.localScale = new Vector3(((player.life - 50F)/100F*2F)+2F,((player.life - 50F)/100F*2F)+2F,0);
		}
	}
}
