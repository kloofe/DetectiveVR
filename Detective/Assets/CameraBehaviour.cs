using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	public float sensitivityX = 10F;
	public float sensitivityY = 10F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;

	void LateUpdate()
	{
		float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivityX;

		rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);

		transform.position = player.transform.position + offset;
	}
	// Use this for initialization
	void Start () {
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;

		offset = transform.position - player.transform.position;
	}
}
