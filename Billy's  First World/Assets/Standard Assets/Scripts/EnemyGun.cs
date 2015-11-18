using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

	public GameObject EnemyBulletGO;
		
	// Use this for initialization
	void Start () {
		//fire an enemy bullet after 1 second
		Invoke ("FireEnemyBullet", 2f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//Function to fire an enemy bullet
	void FireEnemyBullet(){
		// get a reference to the players ship
		GameObject playerBilly = GameObject.Find ("Character");
		

			//instantiate an enemy bullet
		GameObject bullet = (GameObject)Instantiate (EnemyBulletGO);
			
			//set the bullets initial poisition
			bullet.transform.position = transform.position;
			
			//compute the bullets position to Billy
			Vector2 direction = playerBilly.transform.position - bullet.transform.position;
			
			//set bullets direciton
			bullet.GetComponent<EnemyBullet>().SetDirection(direction);
			

	
}
}
