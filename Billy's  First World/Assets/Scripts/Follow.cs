using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	//create a separate class to make the code useable
	public float xMin, xMax, yMin, yMax;
}

public class Follow : MonoBehaviour {
    
	Transform player;
	Transform bound;

	public float speed;
	public Boundary boundary;

	

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		bound = GameObject.FindGameObjectWithTag ("Boundary").GetComponent<Transform>();


		boundary.xMin = 13f;
		boundary.yMax = -8f;


		boundary.xMax = bound.position.x * 2 - 14f; //50
		boundary.yMin = bound.position.y * 2 + 5f;  //-45
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 
			(
				Mathf.Clamp (player.transform.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (player.transform.position.y, boundary.yMin, boundary.yMax),
				-20f
			);
	

	}




}
