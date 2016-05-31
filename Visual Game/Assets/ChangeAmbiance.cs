using UnityEngine;
using System.Collections;

public class ChangeAmbiance : MonoBehaviour {

	public GameObject ambiance;

	public bool exitLighthouse;

	public AudioClip outAmbiance;
	public AudioClip inAmbiance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			if(exitLighthouse) {
				ambiance.GetComponent<AudioSource>().clip = outAmbiance;
				ambiance.GetComponent<AudioSource>().Play();
				exitLighthouse = false;
			} else {
				ambiance.GetComponent<AudioSource>().clip = inAmbiance;
				ambiance.GetComponent<AudioSource>().Play();
				exitLighthouse = true;
			}
		}
	}
}
