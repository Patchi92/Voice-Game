using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Blink();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Blink() {
		if(gameObject.GetComponent<Light>().intensity == 2) {
			gameObject.GetComponent<Light>().intensity = 0;
		} else {
			gameObject.GetComponent<Light>().intensity = 2;
		}

		Invoke("Blink",1);
	}
}
