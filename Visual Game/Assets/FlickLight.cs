using UnityEngine;
using System.Collections;

public class FlickLight : MonoBehaviour {

	float rnd;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		rnd = Random.Range(1,3);
		gameObject.GetComponent<Light>().intensity = rnd;
	}
}
