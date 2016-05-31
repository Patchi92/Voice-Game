using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerChapterTwo : MonoBehaviour {

	public GameObject narrator;
	public GameObject infoText;

	public string itemName;

	public bool interact;


	public bool helloKitchen;
	public bool changeInFrame;
	public bool unusualLight;
	public bool answerComePartOne;
	public bool answerComePartTwo;
	public bool answerComeAgainPartOne;
	public bool answerComeAgainPartTwo;
	public bool whoAreYou;
	public bool aknowledgeYourself;
	public bool rememberName;
	public bool realiseName;

	public bool remember;
	public bool rememberMe;
	public bool madeleine;


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
				narrator.GetComponent<NarratorChapterTwo>().TurnTextOn();

			}

			if(narrator.GetComponent<AudioSource>().isPlaying) {



			} else {


				if(interact) {

					if(Input.GetKeyDown(KeyCode.E)) {



						narrator.GetComponent<NarratorChapterTwo>().TurnTextOff();
					}


				} else {

					if(helloKitchen) {
						narrator.GetComponent<NarratorChapterTwo>().KitchenHello();
						Destroy(gameObject);
					}

					if(changeInFrame) {
						narrator.GetComponent<NarratorChapterTwo>().StrangeFrame();
						Destroy(gameObject);
					}


					if(unusualLight) {
						narrator.GetComponent<NarratorChapterTwo>().UnusualLight();
						Destroy(gameObject);
					}

					if(answerComePartOne) {
						narrator.GetComponent<NarratorChapterTwo>().LighthouseEnterOne();
						Destroy(gameObject);
					}

					if(answerComePartTwo) {
						narrator.GetComponent<NarratorChapterTwo>().LighthouseEnterTwo();
						Destroy(gameObject);
					}

					if(answerComeAgainPartOne) {
						narrator.GetComponent<NarratorChapterTwo>().LighthouseEnterThree();
						Destroy(gameObject);
					}

					if(answerComeAgainPartTwo) {
						narrator.GetComponent<NarratorChapterTwo>().LighthouseEnterFour();
						Destroy(gameObject);
					}

					if(whoAreYou) {
						narrator.GetComponent<NarratorChapterTwo>().LighthouseTopQuestionOne();
						Destroy(gameObject);
					}

					if(aknowledgeYourself) {
						narrator.GetComponent<NarratorChapterTwo>().LighthouseTopQuestionTwo();
						Destroy(gameObject);
					}

					if(rememberName) {
						narrator.GetComponent<NarratorChapterTwo>().LighthouseTopQuestionThree();
						Destroy(gameObject);
					}

					if(realiseName) {
						narrator.GetComponent<NarratorChapterTwo>().LighthouseTopQuestionFour();
						Destroy(gameObject);
					}



				}

			}

			// Madeleine

			if(remember) {
				narrator.GetComponent<NarratorChapterTwo>().MadeleineRemember();
				Destroy(gameObject);
			}

			if(rememberMe) {
				narrator.GetComponent<NarratorChapterTwo>().MadeleineRememberMe();
				Destroy(gameObject);
			}

			if(madeleine) {
				narrator.GetComponent<NarratorChapterTwo>().MadeleineMadeleine();
				Destroy(gameObject);
			}

		}

	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			narrator.GetComponent<NarratorChapterTwo>().TurnTextOff();

		}
	}



}
