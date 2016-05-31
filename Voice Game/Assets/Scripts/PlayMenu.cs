using UnityEngine;
using System.Collections;

public class PlayMenu : MonoBehaviour {

	public MovieTexture menuMovie;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = menuMovie as MovieTexture;
		menuMovie.Play();
		menuMovie.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play() {
		GetComponent<Renderer>().material.mainTexture = menuMovie as MovieTexture;
		menuMovie.Play();
	}

	public void Stop() {
		menuMovie.Stop();
	}
}
