using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NarratorChapterTwo : MonoBehaviour {

	public GameObject player;

	public GameObject bedDoor;
	public GameObject kitchenDoor;
	public GameObject hallDoor;
	public GameObject houseDoor;
	public GameObject LighthouseDoor;

	public GameObject soundEffect;

	AudioSource player_Dialog;
	AudioSource sound_Effect;

	// UI

	public GameObject fade;
	public GameObject speaking;
	public GameObject interactText;
	public GameObject infoText;


	//Sound Files

	public AudioClip intro;
	public AudioClip helloKitchen;
	public AudioClip changeInFrame;
	public AudioClip unusualLight;
	public AudioClip answerComePartOne;
	public AudioClip answerComePartTwo;
	public AudioClip answerComeAgainPartOne;
	public AudioClip answerComeAgainPartTwo;
	public AudioClip whoAreYou;
	public AudioClip aknowledgeYourself;
	public AudioClip rememberName;
	public AudioClip realiseName;

	// Door

	public bool unlockLightDoorOne = false;

	// Use this for initialization
	void Start () {
	
		player_Dialog = GetComponent<AudioSource>();
		sound_Effect = soundEffect.GetComponent<AudioSource>();

		bedDoor.GetComponent<OpenDoor>().DoorFunction();
		kitchenDoor.GetComponent<OpenDoor>().DoorFunction();
		houseDoor.GetComponent<OpenDoor>().DoorFunction();
		LighthouseDoor.GetComponent<OpenDoor>().DoorFunction();

		player.GetComponent<MovementScript>().playerLockdown = false;

		fade.SetActive(true);
		fade.GetComponent<FadeBlack>().FadeOut();
		player.GetComponent<MovementScript>().StunPlayer(4);
		Invoke("Begin",2);
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

		if(gameObject.GetComponent<AudioSource>().isPlaying) {
			interactText.GetComponent<Text>().text = "Waiting for you to stop talking";
		} else {
			interactText.GetComponent<Text>().text = "Press 'E' to interact";
		}
	}

	public void TurnTextOff() {
		interactText.SetActive(false);
		infoText.SetActive(false);
	}


	public void Begin() {
		player_Dialog.clip = intro;
		player_Dialog.Play();
	}

	public void KitchenHello() {
		player_Dialog.clip = helloKitchen;
		player_Dialog.Play();
	}

	public void StrangeFrame() {
		player_Dialog.clip = changeInFrame;
		player_Dialog.Play();

		Invoke("OpenDoorToLight",6);
	}

	public void OpenDoorToLight() {
		hallDoor.GetComponent<OpenDoor>().DoorFunction();
	}

	public void UnusualLight() {
		player_Dialog.clip = unusualLight;
		player_Dialog.Play();
	}

	public void LighthouseEnterOne() {
		player_Dialog.clip = answerComePartOne;
		player_Dialog.Play();
	}

	public void LighthouseEnterTwo() {
		player_Dialog.clip = answerComePartTwo;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().speed = 5;
	}

	public void LighthouseEnterThree() {
		player_Dialog.clip = answerComeAgainPartOne;
		player_Dialog.Play();
	}

	public void LighthouseEnterFour() {
		player_Dialog.clip = answerComeAgainPartTwo;
		player_Dialog.Play();
	}

	public void LighthouseTopQuestionOne() {
		player_Dialog.clip = whoAreYou;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().speed = 2;
	}

	public void LighthouseTopQuestionTwo() {
		player_Dialog.clip = aknowledgeYourself;
		player_Dialog.Play();
	}

	public void LighthouseTopQuestionThree() {
		player_Dialog.clip = rememberName;
		player_Dialog.Play();
	}

	public void LighthouseTopQuestionFour() {
		player_Dialog.clip = realiseName;
		player_Dialog.Play();

		Invoke("Fade",2);
		Invoke("NextLevel",8);
	}



	void Fade() {
		fade.SetActive(true);
		fade.GetComponent<FadeBlack>().FadeIn();
	}

	void NextLevel() {
		//Application.LoadLevel(2);
	}
}
