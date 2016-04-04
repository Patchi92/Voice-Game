using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject narrator;

	public bool interact;

	public bool routine;
	public bool window;
	public bool cloth;
	public bool waterbasin;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "Player") {

			if(interact) {
				narrator.GetComponent<Narrator>().TurnTextOn();
			}

			if(narrator.GetComponent<AudioSource>().isPlaying) {

				Debug.Log("Nope");

			} else {

				if(interact) {


					if(Input.GetKey(KeyCode.E)) {
						
						if(waterbasin) {
							narrator.GetComponent<Narrator>().WaterBasin();
							Destroy(this);
						}

						if(cloth) {
							narrator.GetComponent<Narrator>().Cloth();
							Destroy(gameObject);
						}

						if(window) {
							narrator.GetComponent<Narrator>().Window();
							Destroy(gameObject);
						}

						narrator.GetComponent<Narrator>().TurnTextOff();
					}


				} else {

					if(routine) {
						narrator.GetComponent<Narrator>().Routine();
						Destroy(gameObject);
					}



				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			narrator.GetComponent<Narrator>().TurnTextOff();

		}
	}

}
