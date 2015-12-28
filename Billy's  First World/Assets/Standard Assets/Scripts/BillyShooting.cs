using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller3))]

public class BillyShooting : MonoBehaviour {
	
	
	public GameObject shot;
	public Transform shotSpawn;
	
	public float fireRate;
	
	private float nextFire;

	Animator anim;
	
	
	void Start()
	{
		anim = GetComponent<Animator>();
		fireRate = 0.5f;	

	}
	
	void FixedUpdate()
	{
		if ( Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			float curX = anim.GetFloat("X");
			float curY = anim.GetFloat("Y");

			

			//if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.Walking")){


				if(curX == 1 && curY == 0){ //facing east

					Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				} else if(curX == -1 && curY == 0){ //facing west
					Instantiate(shot, new Vector3(shotSpawn.position.x-2f, shotSpawn.position.y, shotSpawn.position.z), Quaternion.Euler(0, 180, 0));
				} else if(curX == 0 && curY == 1){ //facing north
					Instantiate(shot, new Vector3(shotSpawn.position.x-1f, shotSpawn.position.y+1f, shotSpawn.position.z), Quaternion.Euler(0, 0, 90));
				} else if(curX == 0 && curY == -1){ //facing south
					Instantiate(shot, new Vector3(shotSpawn.position.x-1f, shotSpawn.position.y-1f, shotSpawn.position.z), Quaternion.Euler(0, 0, 270));
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