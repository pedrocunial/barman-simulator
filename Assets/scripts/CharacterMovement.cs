using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.ConstrainedExecution;

public class CharacterMovement : MonoBehaviour
{

	public float speed;
	public float maxDistance;
	public float goTime;
	public float leaveTime;
	public GameObject finalObjective;

	// the infamous brazilian gambiarra
	private bool actionEnded;
	private float timer;
	private Vector3 originalPosition;

	private readonly float TOLERABLE_DISTANCE = 0.01f;


	// Use this for initialization
	void Start ()
	{
		timer = 0.0f;
		originalPosition = transform.position;
		actionEnded = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		move ();
	}

	private void move ()
	{
		float distance = Vector3.Distance (transform.position,
			                 finalObjective.transform.position);
		distance = distance > 0 ? distance : -distance;  // abs

		timer += Time.deltaTime;

		if (timer > goTime && timer < leaveTime) {
			if (distance > maxDistance) {
				// Only move when not at the bar
				transform.position = new Vector3 (
					transform.position.x,
					transform.position.y,
					transform.position.z + speed
				);
			}
		} else if (timer > leaveTime) {
			float originalDistance = Vector3.Distance (
				                         transform.position, originalPosition);
			if (!actionEnded) {
				if (originalDistance > TOLERABLE_DISTANCE) {
					transform.position = new Vector3 (
						transform.position.x,
						transform.position.y,
						transform.position.z - speed
					);
				} else if (originalDistance < -TOLERABLE_DISTANCE) {
					transform.position = new Vector3 (
						transform.position.x,
						transform.position.y,
						transform.position.z + speed
					);
				} else {
					actionEnded = true;
				}
			}
		}
	}
}