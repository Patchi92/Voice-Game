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
	public GameObject madeleine;

	AudioSource player_Dialog;
	AudioSource sound_Effect;
	AudioSource sound_Madeleine;

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

	//Sound Files Madeleine

	public AudioClip sound_Remember;
	public AudioClip sound_MadeleineMadeleine;
	public AudioClip sound_RememberMe;


	// Door

	public bool unlockLightDoorOne = false;

	// Use this for initialization
	void Start () {
	
		player_Dialog = GetComponent<AudioSource>();
		sound_Effect = soundEffect.GetComponent<AudioSource>();
		sound_Madeleine = madeleine.GetComponent<AudioSource>();

		bedDoor.GetComponent<OpenDoor>().DoorFunction();
		kitchenDoor.GetComponent<OpenDoor>().DoorFunction();
		houseDoor.GetComponent<OpenDoor>().DoorFunction();
		LighthouseDoor.GetComponent<OpenDoor>().DoorFunction();

		player.GetComponent<MovementScript>().playerLockdown = false;

		fade.SetActive(true);
		fade.GetComponent<FadeBlack>().FadeOut();
		player.GetComponent<MovementScript>().StunPlayer(4);
		Invoke("Begin",3);
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
			interactText.GetComponent<Text>().text = "Wait until monolog is finished";
		} else {
			interactText.GetComponent<Text>().text = "Press 'E'";
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

		Invoke("MadeleineRememberMe",5);
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

		player.GetComponent<MovementScript>().speed = 2;

		Invoke("Fade",12);
		Invoke("NextLevel",19);

	}

	public void LighthouseTopQuestionThree() {
		player_Dialog.clip = rememberName;
		player_Dialog.Play();

		Invoke("MadeleineMadeleine",3);
		Invoke("LighthouseTopQuestionFour",5);
	}

	public void LighthouseTopQuestionFour() {
		player_Dialog.clip = realiseName;
		player_Dialog.Play();

		Invoke("Fade",12);
		Invoke("NextLevel",10);
	}


	public void MadeleineRemember() {
		sound_Madeleine.clip = sound_Remember;
		sound_Madeleine.Play();
	}

	public void MadeleineRememberMe() {
		sound_Madeleine.clip = sound_RememberMe;
		sound_Madeleine.Play();
	}

	public void MadeleineMadeleine() {
		sound_Madeleine.clip = sound_MadeleineMadeleine;
		sound_Madeleine.Play();
	}



	void Fade() {
		fade.SetActive(true);
		fade.GetComponent<FadeBlack>().FadeIn();
	}

	void NextLevel() {
		Application.LoadLevel(2);
	}
}
