using UnityEngine;
using System.Collections;

public class Narrator : MonoBehaviour {


	public GameObject bedDoor;
	public GameObject kitchenDoor;
	public GameObject hallDoor;
	public GameObject houseDoor;

	AudioSource player_Dialog;
	public AudioClip TestSound;

	// Use this for initialization
	void Start () {
	
		player_Dialog = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {



	}

	public void Test () {
		Debug.Log("lol2");
		player_Dialog.clip = TestSound;
		player_Dialog.Play();

		houseDoor.GetComponent<OpenDoor>().DoorFunction();
		bedDoor.GetComponent<OpenDoor>().DoorFunction();
		kitchenDoor.GetComponent<OpenDoor>().DoorFunction();
		hallDoor.GetComponent<OpenDoor>().DoorFunction();
	}

	public void DayOne () {

	}

	public void DayTwo () {

	}

	public void DayThree () {

	}

	public void DayFour () {

	}
}
