using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {
		// Destroy everything that leaves the trigger
		if (other.gameObject.CompareTag ("enemybullet") || other.gameObject.CompareTag ("bullet")) {
			Destroy (other.gameObject);
		}
	}

}
