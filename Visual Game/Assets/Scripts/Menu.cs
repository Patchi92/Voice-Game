using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GameObject Movie;
	public GameObject MainMenu;
	public GameObject Narrator;
	public GameObject Player;
	public GameObject Fade;

	public GameObject Lighthouse;
	public GameObject House;
	public GameObject Enviroment;

	public GameObject Spawn;

	// Use this for initialization
	void Start () {

		Cursor.visible = true;

		Lighthouse.SetActive(false);
		House.SetActive(false);
		Enviroment.SetActive(false);

		Spawn.SetActive(true);


	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void FadeFunction() {
		Cursor.visible = false;
		Fade.SetActive(true);
		Fade.GetComponent<FadeBlack>().FadeIn();
		Invoke("Begin",6);

	}

	void Begin() {
		Lighthouse.SetActive(true);
		House.SetActive(true);
		Enviroment.SetActive(true);

		Spawn.SetActive(false);


		Fade.GetComponent<FadeBlack>().FadeOut();
		Movie.GetComponent<PlayMenu>().Stop();
		Narrator.GetComponent<NarratorChapterOne>().Begin();
		Player.GetComponent<MovementScript>().playerLockdown = false;
		Movie.SetActive(false);
		MainMenu.SetActive(false);
	}

	public void Exit() {
		Application.Quit();
	}
}
