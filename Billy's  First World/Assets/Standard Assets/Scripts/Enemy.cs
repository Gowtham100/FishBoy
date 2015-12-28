using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int life;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (life == 0) {
			DestroyObject(gameObject);
		}
	}
}
