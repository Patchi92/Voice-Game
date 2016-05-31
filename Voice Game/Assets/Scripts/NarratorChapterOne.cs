using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NarratorChapterOne : MonoBehaviour {

	// Audio

	public GameObject player;

	public GameObject bedDoor;
	public GameObject kitchenDoor;
	public GameObject hallDoor;
	public GameObject houseDoor;
	public GameObject LighthouseDoor;
	public GameObject lightSwitch;

	public GameObject lighthouseLight;
	public GameObject lighthouseSwtichSound;

	AudioSource player_Dialog;

	//Chapter 1

	public AudioClip intro;
	public AudioClip routine;
	public AudioClip waterbasin;
	public AudioClip cloth;
	public AudioClip window;
	public AudioClip doorMissingBoth;
	public AudioClip doorMissingWater;
	public AudioClip doorMissingCloth;

	public AudioClip mainDoor;

	public AudioClip radioNoise;
	public AudioClip drinkCoffee;
	public AudioClip noteOnTable;
	public AudioClip frameNoMotive;
	public AudioClip windowKitchen;

	public AudioClip lightIsOn;
	public AudioClip cellarDoor;
	public AudioClip lightIsOff;

	public AudioClip goingUp;
	public AudioClip onTheWay;
	public AudioClip caretaker;


	public GameObject soundEffect;

	AudioSource sound_Effect;
	public AudioClip sound_cloth;
	public AudioClip sound_waterbasin;
	public AudioClip sound_openDoor;
	public AudioClip sound_radio;
	public AudioClip sound_paper;
	public AudioClip sound_switch;

	// UI

	public GameObject fade;
	public GameObject speaking;
	public GameObject interactText;
	public GameObject infoText;


	// Path Unlocks

	bool unlockBedDoorOne = false;
	bool unlockBedDoorTwo = false;
	public GameObject doneBedDoor;

	public bool unlockLightDoorOne = false;
	public bool unlockLightDoorTwo = false;
	public GameObject doneLightDoor;


	// Obejcts

	public GameObject radioStatic;
	public GameObject waterInteract;
	public GameObject lighthouseSwitchLight;


	// Use this for initialization
	void Start () {
	
		player_Dialog = GetComponent<AudioSource>();
		sound_Effect = soundEffect.GetComponent<AudioSource>();


	}
	
	// Update is called once per frame
	void Update () {

		if(player_Dialog.isPlaying) {
			speaking.SetActive(true);
		}

		if(!player_Dialog.isPlaying) {
			speaking.SetActive(false);
		}
			
		if(unlockLightDoorOne & unlockLightDoorTwo) {
			lighthouseLight.GetComponent<Light>().intensity = 0;
		}


	}


	public void Begin() {

		player.GetComponent<MovementScript>().StunPlayer(6);

		player_Dialog.clip = intro;
		player_Dialog.Play();
	}


	public void TurnTextOn() {
		interactText.SetActive(true);
		infoText.SetActive(true);

		if(gameObject.GetComponent<AudioSource>().isPlaying) {
			interactText.GetComponent<Text>().text = "Wait until monolog is finished";
		} else {
			interactText.GetComponent<Text>().text = "Press 'E'";
		}
	}

	public void TurnTextOff() {
		interactText.SetActive(false);
		infoText.SetActive(false);
	}
		

	public void Routine () {
		player_Dialog.clip = routine;
		player_Dialog.Play();

		fade.SetActive(false);

	}

	public void Window () {
		player_Dialog.clip = window;
		player_Dialog.Play();

	}

	public void Door () {

		if(!unlockBedDoorOne & !unlockBedDoorTwo) {
			player_Dialog.clip = doorMissingBoth;
			player_Dialog.Play();
		}

		if (unlockBedDoorOne & !unlockBedDoorTwo) {
			player_Dialog.clip = doorMissingCloth;
			player_Dialog.Play();
		}

		if (!unlockBedDoorOne & unlockBedDoorTwo) {
			player_Dialog.clip = doorMissingWater;
			player_Dialog.Play();
		}

		if(unlockBedDoorOne & unlockBedDoorTwo) {
			bedDoor.GetComponent<OpenDoor>().DoorFunction();
			kitchenDoor.GetComponent<OpenDoor>().DoorFunction();
			hallDoor.GetComponent<OpenDoor>().DoorFunction();
			unlockBedDoorOne = false;
			unlockBedDoorTwo = false;
			Destroy(doneBedDoor);

			sound_Effect.clip = sound_openDoor;
			sound_Effect.Play();

		}

	}

	public void WaterBasin () {
		player_Dialog.clip = waterbasin;
		player_Dialog.Play();

		sound_Effect.clip = sound_waterbasin;
		sound_Effect.Play();

		Destroy(waterInteract);
		player.GetComponent<MovementScript>().StunPlayer(3);
		unlockBedDoorOne = true;

	}

	public void Cloth () {
		player_Dialog.clip = cloth;
		player_Dialog.Play();

		sound_Effect.clip = sound_cloth;
		sound_Effect.Play();

		player.GetComponent<MovementScript>().StunPlayer(3);
		unlockBedDoorTwo = true;
	}

	public void MainDoor() {
		player_Dialog.clip = mainDoor;
		player_Dialog.Play();

	}

	public void Radio() {
		sound_Effect.clip = sound_radio;
		sound_Effect.Play();

		radioStatic.GetComponent<AudioSource>().Play();

		Invoke("RadioTwo",2);
	}

	void RadioTwo() {
		player_Dialog.clip = radioNoise;
		player_Dialog.Play();
	}

	public void Coffee() {
		player_Dialog.clip = drinkCoffee;
		player_Dialog.Play();
	}

	public void Note() {
		player_Dialog.clip = noteOnTable;
		player_Dialog.Play();

		sound_Effect.clip = sound_paper;
		sound_Effect.Play();

		unlockLightDoorTwo = true;
	}

	public void Picture() {
		player_Dialog.clip = frameNoMotive;
		player_Dialog.Play();

		unlockLightDoorOne = true;
	}

	public void WindowKitchen () {
		player_Dialog.clip = windowKitchen;
		player_Dialog.Play();

	}


	public void LightPanel() {
		player_Dialog.clip = lightIsOff;
		player_Dialog.Play();

	}

	public void LightDoor() {

		if(unlockLightDoorOne & unlockLightDoorTwo) {
			houseDoor.GetComponent<OpenDoor>().DoorFunction();
			LighthouseDoor.GetComponent<OpenDoor>().DoorFunction();
			Destroy(doneLightDoor);

			sound_Effect.clip = sound_openDoor;
			sound_Effect.Play();
		} else {
			player_Dialog.clip = lightIsOn;
			player_Dialog.Play();
		}

	}

	public void Cellar() {
		player_Dialog.clip = cellarDoor;
		player_Dialog.Play();
	}

	public void EnterStair() {
		player_Dialog.clip = goingUp;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().speed = 5;
	}

	public void OnStair() {
		player_Dialog.clip = onTheWay;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().speed = 2;
	}

	public void LightSwitch() {
		player_Dialog.clip = caretaker;
		player_Dialog.Play();

		sound_Effect.clip = sound_switch;
		sound_Effect.Play();

		lightSwitch.GetComponent<OpenDoor>().DoorFunction();
		Invoke("StartLighthouse",1);
		Invoke("Fade",12);
		Invoke("NextLevel",20);

	}

	void StartLighthouse() {
		lighthouseSwitchLight.SetActive(true);
		lighthouseSwtichSound.GetComponent<AudioSource>().Play();
	}


	void Fade() {
		fade.SetActive(true);
		fade.GetComponent<FadeBlack>().FadeIn();
	}

	void NextLevel() {
		Application.LoadLevel(1);
	}
}
