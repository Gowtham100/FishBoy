using UnityEngine;
using System.Collections;

public class LvlManager : MonoBehaviour {
	
	public GameObject currentCheckpoint;
	public Controller2 player;
	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<Controller2> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer(){
		Debug.Log ("Respawn here!!!!");
		player.transform.position = currentCheckpoint.transform.position;

		// make bubble big and set health
		player.transform.Find("Bubble").localScale = new Vector3(4,4,0);
		player.life = 4;

	}
}
