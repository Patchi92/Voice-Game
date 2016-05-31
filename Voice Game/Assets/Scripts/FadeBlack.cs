using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour {


	bool fadeOut = false;
	bool fadeIn = false;

	Color alphaColor = new Color(1f,1f,1f,0f);

	float lerp = 0;
	float duration = 5;


	// Use this for initialization
	void Start () {
	
		gameObject.GetComponent<Image>().color = alphaColor;
	
	}
	
	// Update is called once per frame
	void Update () {

		lerp += Time.deltaTime / duration;

		if(fadeIn) {

			gameObject.GetComponent<Image>().color = alphaColor;
			alphaColor.a = Mathf.Lerp(0f,1f,lerp);
		}


		if(fadeOut) {
			
			gameObject.GetComponent<Image>().color = alphaColor;
			alphaColor.a = Mathf.Lerp(1f,0f,lerp);
		}
			
	}

	public void FadeIn() {

		lerp = 0;
		fadeOut = false;
		fadeIn = true;

	}

	public void FadeOut() {

		lerp = 0;
		fadeIn = false;
		fadeOut = true;
	}
}
