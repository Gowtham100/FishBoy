using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LvlManager : MonoBehaviour {
	
	public GameObject playerRespawn;
	public Controller3 player;

	public GameObject flowerEnemy; //update this as more enemies are created

	public GameObject[] respawns;
	public GameObject[] enemies;
	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<Controller3> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer(){
		respawns = GameObject.FindGameObjectsWithTag("Respawn");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		Debug.Log ("Respawn here!!!!");
		player.transform.position = playerRespawn.transform.position;

		for (int i = 0; i < enemies.Length; i ++) {
			Destroy(enemies[i]);
		}

		for(int i = 0 ; i < respawns.Length; i ++){
			if (respawns[i].GetComponent<Checkpoints>().type.Equals("Flower")){
				Instantiate(flowerEnemy, respawns[i].transform.position, respawns[i].transform.rotation);
			}
		}

	}
}
