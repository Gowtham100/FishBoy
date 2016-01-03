using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller3))]

public class BillyShooting : MonoBehaviour {
	
	
	public GameObject shot;
	public Transform shotSpawn;
	
	public float fireRate;
	
	private float nextFire;

	Animator anim;

	Controller3 player;
	
	
	void Start()
	{
		fireRate = 0.5f;

		anim = GetComponent<Animator>();
		player = GetComponent<Controller3> ();

	}
	
	void FixedUpdate()
	{
		if ( (Input.GetButton("Fire1") || Input.GetButton("Fire2")) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			float curX = anim.GetFloat("X");
			float curY = anim.GetFloat("Y");

			

			//if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.Shooting")){


				if(curX == 1 && curY == 0){ //facing east
					Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
					player.life--;
				} else if(curX == -1 && curY == 0){ //facing west
					Instantiate(shot, new Vector3(shotSpawn.position.x-2f, shotSpawn.position.y, shotSpawn.position.z), Quaternion.Euler(0, 180, 0));
					player.life--;
				} else if(curX == 0 && curY == 1){ //facing north
					Instantiate(shot, new Vector3(shotSpawn.position.x-1f, shotSpawn.position.y+1f, shotSpawn.position.z), Quaternion.Euler(0, 0, 90));
					player.life--;
				} else if(curX == 0 && curY == -1){ //facing south
					Instantiate(shot, new Vector3(shotSpawn.position.x-1f, shotSpawn.position.y-1f, shotSpawn.position.z), Quaternion.Euler(0, 0, 270));
					player.life--;
				}
			//}
		}
	}

//	public void Attack(bool isEnemy)
//	{
//		if (CanAttack)
//		{
//			shootCooldown = shootingRate;
//			
//			// Create a new shot
//			var shotTransform = Instantiate(shotPrefab) as Transform;
//			
//			// Assign position
//			shotTransform.position = transform.position;
//			
//			// The is enemy property
//			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
//			if (shot != null)
//			{
//				shot.isEnemyShot = isEnemy;
//				
//			}
//			
//			// Make the weapon shot always towards it
//			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
//			Controller3 face = shotTransform.gameObject.GetComponent<Controller3>();
//			if (move != null)
//			{
//				
//				move.direction = this.transform.right; // towards in 2D space is the right of the sprite
//				
//
//
//
//				
//			}
//			
//			
//			
//		}
//	}
	

}