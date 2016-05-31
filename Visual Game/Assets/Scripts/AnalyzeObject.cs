using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnalyzeObject : MonoBehaviour {

	public GameObject infoText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit)) {

			if(hit.collider.tag == "Readable") {
				//infoText.GetComponent<Text>().text = hit.collider.gameObject.name;
			} else {
				//infoText.GetComponent<Text>().text = " ";
			}


		}
		
	}
}
