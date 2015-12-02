using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
    GameObject character;
	// Use this for initialization
	void Start () {
        character = GameObject.Find("Billy");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -20);
	}
}
