using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftMovement : MonoBehaviour {

	private Rigidbody camRigidbody;

	[Range(10, 1000)]
	public float Force = 3;

	private bool PaddleIn;

	// Use this for initialization
	void Start () {
		camRigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		float xInput = Input.GetAxis ("Horizontal");
		float yInput = Input.GetAxis ("Vertical");

		if (PaddleIn == false && (xInput !=0 || yInput != 0)) {
			
			Vector3 currentInput = new Vector3 (xInput, 0, yInput) * Force;

			Vector3 currentVelocity = camRigidbody.velocity;

			Vector3 heading = currentInput.normalized - currentVelocity.normalized;

			camRigidbody.AddForce (currentInput + (Vector3.Scale(currentVelocity, heading)));

			PaddleIn = true;
			Debug.Log ("Paddle");
			Debug.Log (heading);

		} 

		if (xInput == 0 && yInput == 0) {
			PaddleIn = false;
		}


	}
}
