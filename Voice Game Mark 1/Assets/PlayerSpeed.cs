using UnityEngine;
using System.Collections;

public class PlayerSpeed : MonoBehaviour {

	public float speedUp;
	public float speedDown;
	public bool speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			if(speed) {
				other.gameObject.GetComponent<MovementScript>().speed = speedUp;
				speed = false;
			} else {
				other.gameObject.GetComponent<MovementScript>().speed = speedDown;
				speed = true;
			}
		}
	}
}
