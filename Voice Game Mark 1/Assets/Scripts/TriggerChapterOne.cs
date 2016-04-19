using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerChapterOne : MonoBehaviour {

	public GameObject narrator;
	public GameObject infoText;

	public string itemName;

	public bool interact;

	public bool routine;
	public bool window;
	public bool cloth;
	public bool waterbasin;
	public bool door;
	public bool mainDoor;
	public bool radio;
	public bool coffee;
	public bool note;
	public bool picture;
	public bool windowKitchen;
	public bool lightPanel;
	public bool lightDoor;
	public bool cellar;
	public bool enterStair;
	public bool onStair;
	public bool lightSwitch;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	

		if(lightPanel) {
			if(!narrator.GetComponent<AudioSource>().isPlaying) {
				if(narrator.GetComponent<NarratorChapterOne>().unlockLightDoorOne & narrator.GetComponent<NarratorChapterOne>().unlockLightDoorTwo) {
					narrator.GetComponent<NarratorChapterOne>().LightPanel();
					Destroy(gameObject);
				}
			}
		}

	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "Player") {

			if(interact) {
				infoText.GetComponent<Text>().text = itemName;
				narrator.GetComponent<NarratorChapterOne>().TurnTextOn();

			}

			if(narrator.GetComponent<AudioSource>().isPlaying) {



			} else {
				

				if(interact) {


					if(Input.GetKeyDown(KeyCode.E)) {
						
						if(waterbasin) {
							narrator.GetComponent<NarratorChapterOne>().WaterBasin();
							Destroy(this);
						}

						if(cloth) {
							narrator.GetComponent<NarratorChapterOne>().Cloth();
							Destroy(gameObject);
						}

						if(window) {
							narrator.GetComponent<NarratorChapterOne>().Window();
							Destroy(gameObject);
						}

						if(door) {
							narrator.GetComponent<NarratorChapterOne>().Door();
						}

						if(mainDoor) {
							narrator.GetComponent<NarratorChapterOne>().MainDoor();
							Destroy(gameObject);
						}

						if(radio) {
							narrator.GetComponent<NarratorChapterOne>().Radio();
							Destroy(gameObject);
						}

						if(coffee) {
							narrator.GetComponent<NarratorChapterOne>().Coffee();
							Destroy(gameObject);
						}

						if(note) {
							narrator.GetComponent<NarratorChapterOne>().Note();
							Destroy(gameObject);
						}

						if(picture) {
							narrator.GetComponent<NarratorChapterOne>().Picture();
							Destroy(gameObject);
						}

						if(windowKitchen) {
							narrator.GetComponent<NarratorChapterOne>().WindowKitchen();
							Destroy(gameObject);
						}

						if(lightDoor) {
							narrator.GetComponent<NarratorChapterOne>().LightDoor();
						}

						if(cellar) {
							narrator.GetComponent<NarratorChapterOne>().Cellar();
							Destroy(gameObject);
						}

						if(lightSwitch) {
							narrator.GetComponent<NarratorChapterOne>().LightSwitch();
							Destroy(gameObject);
						}


						narrator.GetComponent<NarratorChapterOne>().TurnTextOff();
					}


				} else {

					if(routine) {
						narrator.GetComponent<NarratorChapterOne>().Routine();
						Destroy(gameObject);
					}

					if(enterStair) {
						narrator.GetComponent<NarratorChapterOne>().EnterStair();
						Destroy(gameObject);
					}

					if(onStair) {
						narrator.GetComponent<NarratorChapterOne>().OnStair();
						Destroy(gameObject);
					}


				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			narrator.GetComponent<NarratorChapterOne>().TurnTextOff();

		}
	}

}
