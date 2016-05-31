using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {


	float doorSpeed = 1f;

	public Vector3 Closed;
	public Vector3 Open;
	Vector3 Swing;

	bool Door = false;


	void Start () {

		Swing = Closed;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Door) {
			Swing = Vector3.Lerp(Swing, Open, Time.deltaTime * doorSpeed);
			transform.eulerAngles = Swing;

		} else {
			Swing = Vector3.Lerp(Swing, Closed, Time.deltaTime * doorSpeed);
			transform.eulerAngles = Swing;
		}
			
	}

	public void DoorFunction() {
		if(Door) {
			Door = false;
			Swing = Open;
		} else { 
			Door = true;
			Swing = Closed;
		}
	}
}
