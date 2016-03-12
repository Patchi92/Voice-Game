using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject narrator;

	public bool test;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			if(test) {
			Debug.Log("lol");
			narrator.GetComponent<Narrator>().Test();
			Destroy(gameObject);
			}
		}
	}
}
