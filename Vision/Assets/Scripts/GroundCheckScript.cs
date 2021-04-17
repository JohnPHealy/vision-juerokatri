using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour {
	public bool Grounded;

	void OnTriggerStay2D (Collider2D col){ //if the groundcheck is inside the ground or an object with a collider
		Grounded = true;
	}


	void OnTriggerExit2D (Collider2D col){ //if the groundcheck is NOT inside the ground or an object with a collider
		Grounded = false;
	}
}
