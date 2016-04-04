using UnityEngine;
using System.Collections;

public class Sleep : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "Player") {

			other.gameObject.transform.localScale = new Vector3(1, 0.1f, 1);
			other.gameObject.GetComponent<MovementScript>().speed = 1f;

		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {

			other.gameObject.transform.localScale = new Vector3(1, 1, 1);
			other.gameObject.GetComponent<MovementScript>().speed = 2;

		}
	}
}
