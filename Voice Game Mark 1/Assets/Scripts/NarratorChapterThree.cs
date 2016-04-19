using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NarratorChapterThree : MonoBehaviour {

	public GameObject player;

	public GameObject bedDoor;
	public GameObject kitchenDoor;
	public GameObject hallDoor;
	public GameObject houseDoor;
	public GameObject LighthouseDoor;

	public GameObject enterPoint;
	public GameObject leavePoint;
	public GameObject ableToLeave;

	public GameObject movieTime;

	public GameObject lightIsFine;

	public GameObject frame;
	public GameObject frameWithMadeleine;
	public GameObject frameWithLetter;
	public GameObject frameWithMadeleinePoint;
	public GameObject letter;

	public GameObject fineLight;
	public GameObject strangeLight;

	public GameObject lastSection;
	public GameObject choiceTime;

	public GameObject soundEffect;
	public GameObject madeleine;

	AudioSource player_Dialog;
	AudioSource sound_Effect;
	AudioSource sound_Madeleine;

	public GameObject madeleineEnd;
	public GameObject deadPoint;


	bool turnCamLeft = false;
	bool deadEnd = false;
	bool falling = false;

	// UI

	public GameObject fade;
	public GameObject speaking;
	public GameObject interactText;
	public GameObject infoText;

	//Sound Files

	public AudioClip intro;
	public AudioClip key;
	public AudioClip enterCeller;
	public AudioClip filmApparatus;
	public AudioClip filmRemember;
	public AudioClip canIReturn;
	public AudioClip lightOn;
	public AudioClip soundFromRadio;
	public AudioClip pictureFrame;
	public AudioClip letterFromMadeleine;
	public AudioClip readLetterFromMadeleine;
	public AudioClip lightIsStrange;
	public AudioClip runningUp;

	public AudioClip helpMe;
	public AudioClip endingA;
	public AudioClip endingB;

	public AudioClip choiceA;

	// Use this for initialization
	void Start () {

		player_Dialog = GetComponent<AudioSource>();
		sound_Effect = soundEffect.GetComponent<AudioSource>();
		sound_Madeleine = madeleine.GetComponent<AudioSource>();

		bedDoor.GetComponent<OpenDoor>().DoorFunction();
		kitchenDoor.GetComponent<OpenDoor>().DoorFunction();
		houseDoor.GetComponent<OpenDoor>().DoorFunction();

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

		if(deadEnd) {
			player.transform.position = Vector3.MoveTowards(player.transform.position, deadPoint.transform.position, 0.4f * Time.deltaTime);
			player.transform.LookAt(deadPoint.transform);
		}

		if(falling) {
			player.transform.Rotate(Vector3.right * 15f * Time.deltaTime);
		}

		if(turnCamLeft) {
			player.transform.Rotate(Vector3.down * 17 * Time.deltaTime);
			player.GetComponent<MovementScript>().saveRotation = player.transform.rotation * player.GetComponent<MovementScript>().xQuaternionInfo * player.GetComponent<MovementScript>().yQuaternionInfo;
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

		player.GetComponent<MovementScript>().StandUp();
	}

	public void Key() {
		player_Dialog.clip = key;
		player_Dialog.Play();

		LighthouseDoor.GetComponent<OpenDoor>().DoorFunction();
	}

	public void EnterCeller() {
		player_Dialog.clip = enterCeller;
		player_Dialog.Play();

		EnterCellerPoint();
		ableToLeave.SetActive(true);
		houseDoor.GetComponent<OpenDoor>().DoorFunction();
	}

	public void FilmApparatus() {
		player_Dialog.clip = filmApparatus;
		player_Dialog.Play();
	}

	public void FilmRemember() {
		player_Dialog.clip = filmRemember;
		player_Dialog.Play();

		movieTime.SetActive(true);
		Invoke("CanIReturn",70);
	}

	public void CanIReturn() {
		//player_Dialog.clip = canIReturn;
		//player_Dialog.Play();

		movieTime.SetActive(false);
		lightIsFine.SetActive(true);
		hallDoor.GetComponent<OpenDoor>().DoorFunction();
	}

	public void LightOn() {
		player_Dialog.clip = lightOn;
		player_Dialog.Play();

		lightIsFine.SetActive(false);
	}

	public void SoundFromRadio() {
		player_Dialog.clip = soundFromRadio;
		player_Dialog.Play();
	}

	public void MadeleineInFrame() {
		player_Dialog.clip = pictureFrame;
		player_Dialog.Play();

		frameWithMadeleinePoint.SetActive(true);
	}

	public void PictureFrame() {
		frameWithMadeleine.SetActive(false);
		frameWithLetter.SetActive(true);
		frameWithMadeleinePoint.SetActive(false);

		player_Dialog.clip = letterFromMadeleine;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().StunPlayer(3);
		Invoke("LetterFromMadeleine",2);
	}

	public void LetterFromMadeleine() {
		//letter.SetActive(false);
		Invoke("ReadLetterFromMadeleine",6);
	}

	public void ReadLetterFromMadeleine() {
		player_Dialog.clip = readLetterFromMadeleine;
		player_Dialog.Play();

		letter.SetActive(false);
		Invoke("LightIsStrange",62);
	}

	public void LightIsStrange() {
		player_Dialog.clip = lightIsStrange;
		player_Dialog.Play();

		fineLight.SetActive(false);
		strangeLight.SetActive(true);

		houseDoor.GetComponent<OpenDoor>().DoorFunction();
		lastSection.SetActive(true);
		frame.SetActive(false);
	}

	public void RunningUp() {
		player_Dialog.clip = runningUp;
		player_Dialog.Play();
	}

	public void HelpMe() {
		player_Dialog.clip = helpMe;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().playerLockdown = true;
		player.transform.LookAt(madeleineEnd.transform);
		player.transform.eulerAngles = new Vector3(0,player.transform.rotation.y + 190,0);
		choiceTime.SetActive(true);

		Invoke("EndingA",11);
	}

	public void EndingA() {
		player_Dialog.clip = endingA;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().playerLockdown = true;
		player.transform.LookAt(madeleineEnd.transform);
		player.transform.eulerAngles = new Vector3(0,player.transform.rotation.y + 190,0);
		choiceTime.SetActive(true);


		Invoke("EndingB",18);
	}

	public void EndingB() {
		player_Dialog.clip = endingB;
		player_Dialog.Play();

		turnCamLeft = true;

		Invoke("Choice",11.3f);
	}

	public void Choice() {
		madeleineEnd.SetActive(false);
		turnCamLeft = false;
		player.GetComponent<MovementScript>().playerLockdown = false;
		player.GetComponent<MovementScript>().originalRotation = player.GetComponent<MovementScript>().saveRotation;

	}


	public void ChoiceA() {
		player_Dialog.clip = choiceA;
		player_Dialog.Play();

		player.GetComponent<MovementScript>().playerLockdown = true;
		deadEnd = true;

		Invoke("RotateCamDown",8);
		Invoke("ReleasePlayer",15);
		Invoke("Fade",14);
		Invoke("NextLevelEndingA",22);
	}

	public void ChoiceB() {
		fade.GetComponent<FadeBlack>().FadeIn();
		Invoke("NextLevelEndingB",8);
	}

	public void RotateCamDown() {
		falling = true;
	}



	public void ReleasePlayer() {
		player.GetComponent<MovementScript>().playerLockdown = false;
		player.GetComponent<MovementScript>().playerFalling = true;
		deadEnd = false;
		falling = false;

	}


	public void EnterCellerPoint() {
		player.transform.position = leavePoint.transform.position;
		player.transform.rotation = leavePoint.transform.rotation;
	}

	public void LeaveCellerPoint() {
		player.transform.position = enterPoint.transform.position;
		player.transform.rotation = enterPoint.transform.rotation;
	}


	void Fade() {
		fade.SetActive(true);
		fade.GetComponent<FadeBlack>().FadeIn();
	}

	void NextLevelEndingA() {
		Application.LoadLevel(0);
	}

	void NextLevelEndingB() {
		Application.LoadLevel(0);
	}
}
