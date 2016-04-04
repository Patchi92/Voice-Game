using UnityEngine;
using System.Collections;

public class MistTrigger : MonoBehaviour {

	public bool EnterLight;
	public GameObject TowerMist;
	public GameObject HouseMist;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {

			if(EnterLight) {
				HouseMist.SetActive(false);
				TowerMist.SetActive(true);

			} else if(!EnterLight) {
				TowerMist.SetActive(false);
				HouseMist.SetActive(true);
			}


		}
	}
}
