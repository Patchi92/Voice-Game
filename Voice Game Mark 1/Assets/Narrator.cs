using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Narrator : MonoBehaviour {

	public GameObject player;

	public GameObject bedDoor;
	public GameObject kitchenDoor;
	public GameObject hallDoor;
	public GameObject houseDoor;
	public GameObject LighthouseDoor;

	AudioSource player_Dialog;
	public AudioClip intro;
	public AudioClip routine;
	public AudioClip waterbasin;
	public AudioClip cloth;
	public AudioClip door;
	public AudioClip window;

	public GameObject soundEffect;

	AudioSource sound_Effect;
	public AudioClip sound_cloth;
	public AudioClip sound_waterbasin;


	public GameObject fade;
	public GameObject speaking;
	public GameObject interactText;
	public GameObject infoText;

	// Use this for initialization
	void Start () {
	
		player_Dialog = GetComponent<AudioSource>();
		sound_Effect = soundEffect.GetComponent<AudioSource>();

		player_Dialog.clip = intro;
		player_Dialog.Play();

		fade.SetActive(true);


		houseDoor.GetComponent<OpenDoor>().DoorFunction();
		bedDoor.GetComponent<OpenDoor>().DoorFunction();
		kitchenDoor.GetComponent<OpenDoor>().DoorFunction();
		hallDoor.GetComponent<OpenDoor>().DoorFunction();
		LighthouseDoor.GetComponent<OpenDoor>().DoorFunction();


	}
	
	// Update is called once per frame
	void Update () {

		if(player_Dialog.isPlaying) {
			speaking.SetActive(true);
		}

		if(!player_Dialog.isPlaying) {
			speaking.SetActive(false);
		}

	}


	public void TurnTextOn() {
		interactText.SetActive(true);
		infoText.SetActive(true);
	}

	public void TurnTextOff() {
		interactText.SetActive(false);
		infoText.SetActive(false);
		infoText.GetComponent<Text>().text = " ";
	}

	public void Routine () {
		player_Dialog.clip = routine;
		player_Dialog.Play();


	}

	public void Window () {
		player_Dialog.clip = window;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().StunPlayer(1);
	}

	public void Door () {
		player_Dialog.clip = door;
		player_Dialog.Play();

	}

	public void WaterBasin () {
		player_Dialog.clip = waterbasin;
		player_Dialog.Play();

		sound_Effect.clip = sound_waterbasin;
		sound_Effect.Play();

		player.GetComponent<MovementScript>().StunPlayer(3);

	}

	public void Cloth () {
		player_Dialog.clip = cloth;
		player_Dialog.Play();

		sound_Effect.clip = sound_cloth;
		sound_Effect.Play();

		player.GetComponent<MovementScript>().StunPlayer(3);
	}
}
