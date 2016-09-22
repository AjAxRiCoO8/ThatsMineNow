using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PressToPickUp : MonoBehaviour
{

	[Range (0.5f, 10f)]
	public float viewingDistance;
	public Text interactionText;

	public int treasureCount = 0;

	RaycastHit hit;
	float theDistance;
	Vector3 forward;

	// Use this for initialization
	void Update ()
	{
		forward = transform.TransformDirection (Vector3.forward) * viewingDistance;
		Debug.DrawRay (transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, forward, out hit)) {
			//theDistance = hit.distance;
			//print (theDistance + " " + hit.collider.gameObject.tag);

			if (hit.collider.gameObject.CompareTag ("PickUp")) {
				interactionText.text = "Press 'E' to pick up";
				if (Input.GetKeyDown (KeyCode.E)) {
					hit.collider.gameObject.SetActive (false);
					treasureCount++;
					interactionText.text = "";
				}
			} else {
				interactionText.text = "";
			}
		}
	}
}
