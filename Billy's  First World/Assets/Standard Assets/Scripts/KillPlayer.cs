using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {


	public LvlManager levelmanager;
	// Use this for initialization
	void Start () {
		levelmanager = FindObjectOfType<LvlManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Character") {
			levelmanager.RespawnAll();
		}
	
	}
}
