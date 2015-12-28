using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LvlManager : MonoBehaviour {
	
	public GameObject currentCheckpoint;
	public Controller3 player;

	public GameObject flowerEnemy;

	public GameObject[] respawns;
	public GameObject[] enemies;
	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<Controller3> ();
		respawns = GameObject.FindGameObjectsWithTag("Respawn");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer(){
		Debug.Log ("Respawn here!!!!");
		player.transform.position = currentCheckpoint.transform.position;

		for (int i = 0; i < enemies.Length; i ++) {
			Destroy(enemies[i]);
		}

		for(int i = 0 ; i < respawns.Length; i ++){
			Instantiate(flowerEnemy, respawns[i].transform.position, respawns[i].transform.rotation);
		}

	}
}
