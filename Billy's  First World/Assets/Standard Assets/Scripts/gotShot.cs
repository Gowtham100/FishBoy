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

		player = GetComponent<Controller3>();
		levelmanager = FindObjectOfType<LvlManager> ();

		//init bubble with radius
		bubble.transform.localScale = new Vector3(player.radius,player.radius,0);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(player.life <= 0){
			player.playDeadAnim();
			Invoke("respawn",2.5f); //respawn

		}

		if(other.tag == "enemybullet"){
			bubble.transform.localScale = 
				new Vector3(((player.life - 50F)/100F*player.radius)+player.radius,((player.life - 50F)/100F*player.radius)+player.radius,0);
		}
	}

	void respawn(){
		levelmanager.RespawnPlayer ();
	}

}
