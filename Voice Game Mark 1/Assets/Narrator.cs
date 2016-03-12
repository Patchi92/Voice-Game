using UnityEngine;
using System.Collections;

public class Narrator : MonoBehaviour {

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
