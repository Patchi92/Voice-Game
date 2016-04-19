using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerChapterThree : MonoBehaviour {

	public GameObject narrator;
	public GameObject infoText;

	public string itemName;

	public bool interact;

	public bool key;
	public bool cellar;
	public bool filmPartOne;
	public bool filmPartTwo;
	public bool filmPartThree;
	public bool lightOn;
	public bool soundFromRadio;
	public bool madeleineInFrame;
	public bool pictureFrame;
	public bool letter;
	public bool readLetter;
	public bool lightStrange;
	public bool runningUp;

	public bool helpMe;
	public bool endingA;
	public bool endingB;
	public bool choiceA;
	public bool choiceB;


	//Celler

	public bool enterCeller;
	public bool leaveCeller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "Player") {

			if(interact) {
				infoText.GetComponent<Text>().text = itemName;
				narrator.GetComponent<NarratorChapterThree>().TurnTextOn();

			}

			if(narrator.GetComponent<AudioSource>().isPlaying) {



			} else {


				if(interact) {

					if(Input.GetKeyDown(KeyCode.E)) {

						if(key) {
							narrator.GetComponent<NarratorChapterThree>().Key();
							Destroy(gameObject);
						}

						if(cellar) {
							narrator.GetComponent<NarratorChapterThree>().EnterCeller();
							Destroy(gameObject);
						}

						if(filmPartTwo) {
							narrator.GetComponent<NarratorChapterThree>().FilmRemember();
							Destroy(gameObject);
						}

						if(pictureFrame) {
							narrator.GetComponent<NarratorChapterThree>().PictureFrame();
						}

						if(letter) {
							narrator.GetComponent<NarratorChapterThree>().LetterFromMadeleine();
						}

						if(soundFromRadio) {
							narrator.GetComponent<NarratorChapterThree>().SoundFromRadio();
							Destroy(gameObject);
						}

						if(choiceA) {
							narrator.GetComponent<NarratorChapterThree>().ChoiceA();
							Destroy(gameObject);
						}

						if(choiceB) {
							narrator.GetComponent<NarratorChapterThree>().ChoiceB();
							Destroy(gameObject);
						}



						if(enterCeller) {
							narrator.GetComponent<NarratorChapterThree>().EnterCellerPoint();
						}

						if(leaveCeller) {
							narrator.GetComponent<NarratorChapterThree>().LeaveCellerPoint();
						}

						narrator.GetComponent<NarratorChapterThree>().TurnTextOff();
					}


				} else {

					if(filmPartOne) {
						narrator.GetComponent<NarratorChapterThree>().FilmApparatus();
						Destroy(gameObject);
					}

					if(filmPartThree) {
						narrator.GetComponent<NarratorChapterThree>().CanIReturn();
						Destroy(gameObject);
					}

					if(lightOn) {
						narrator.GetComponent<NarratorChapterThree>().LightOn();
					}

					if(readLetter) {
						narrator.GetComponent<NarratorChapterThree>().ReadLetterFromMadeleine();
						Destroy(gameObject);
					}

					if(madeleineInFrame) {
						narrator.GetComponent<NarratorChapterThree>().MadeleineInFrame();
						Destroy(this);
					}

					if(lightStrange) {
						narrator.GetComponent<NarratorChapterThree>().LightIsStrange();
						Destroy(gameObject);
					}

					if(runningUp) {
						narrator.GetComponent<NarratorChapterThree>().RunningUp();
						Destroy(gameObject);
					}

					if(helpMe) {
						narrator.GetComponent<NarratorChapterThree>().HelpMe();
						Destroy(gameObject);
					}

					if(endingA) {
						narrator.GetComponent<NarratorChapterThree>().EndingA();
						Destroy(gameObject);
					}

					if(endingB) {
						narrator.GetComponent<NarratorChapterThree>().EndingB();
						Destroy(gameObject);
					}




				}


			}

		}

	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			narrator.GetComponent<NarratorChapterThree>().TurnTextOff();

		}
	}
}
