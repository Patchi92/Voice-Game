using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	// Player
	bool playercontrol = true;

	//Movement

	public float speed;
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;


	// Look Around

	public enum RotationAxes { MouseXandY = 0, MouseX = 1, MouseY = 2}
	public RotationAxes axes = RotationAxes.MouseXandY;
	public float sensitivityX = 15f;
	public float sensitivityY = 15f;

	public float minimumX = -360f;
	public float maximumX = 360f;
	public float minimumY = -60f;
	public float maximumY = 60f;

	float rotationX = 0f;
	float rotationY = 0f;
	Quaternion originalRotation;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		originalRotation = transform.localRotation;

		StunPlayer(8);
	}
	
	// Update is called once per frame
	void Update () {
	
		//Movement

		CharacterController controller = GetComponent<CharacterController>();
		if(playercontrol) {
			if(controller.isGrounded) {

				moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);

				moveDirection *= speed;

				if(Input.GetButton("Jump")) {
					//Nothing
				}

			}

			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);


			if(Input.GetKeyDown(KeyCode.LeftShift)) {

				speed = 8;
			}

			if(Input.GetKeyUp(KeyCode.LeftShift)) {

				speed = 2;
			}
		}


		// Look Around

		if(axes == RotationAxes.MouseXandY) {

			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationX = ClampAngle(rotationX,minimumX,maximumX);
			rotationY = ClampAngle(rotationY,minimumY,maximumY);
			Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

			transform.localRotation = originalRotation * xQuaternion * yQuaternion;

		} else if (axes == RotationAxes.MouseX) {

			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationX = ClampAngle(rotationX,minimumX,maximumX);
			Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);

			transform.localRotation = originalRotation * xQuaternion;

		} else {

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = ClampAngle (rotationY,minimumY,maximumY);
			Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

			transform.localRotation = originalRotation * yQuaternion;
		}
	}

	public static float ClampAngle (float angle, float min, float max) {
		if(angle < -360f)
			angle += 360f;

		if(angle > 360)
			angle -= 360f;

		return Mathf.Clamp (angle, min, max);

	}


	public void StunPlayer(float time) {
		playercontrol = false;
		Invoke("AwakePlayer",time);

	}

	public void AwakePlayer() {
		playercontrol = true;
	}
}
