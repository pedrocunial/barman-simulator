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

	// the infamous brazilian gambiarra
	private bool actionEnded;
	private bool idleState;
	private float timer;
	private Vector3 originalPosition;
	private Vector3 doorPosition;
	private Animator anim;
	//	private WalkIdleAnimation anim;

	private readonly float TOLERABLE_DISTANCE = 0.1f;

	private void walk ()
	{
		anim.Play ("Basic_Walk_02");
	}

	private void idle ()
	{
		anim.Play ("Idle");
	}

	// Use this for initialization
	void Start ()
	{
		timer = 0.0f;
		originalPosition = transform.position;
		actionEnded = false;
		doorPosition = door.transform.position;
		anim = GetComponent <Animator> ();
		idleState = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		move ();
	}

	private void move ()
	{
		if (timer > goTime && timer < leaveTime) {
			goToBar ();
		} else if (timer > leaveTime) {
			if (!actionEnded) {
				goBack ();
			} else {
				leaveBar ();
			}
		}
	}

	private float absDistance (Vector3 posa, Vector3 posb)
	{
		float distance = Vector3.Distance (posa, posb);
		return distance > 0 ? distance : -distance;  // abs
	}

	private void goBack ()
	{
		if (idleState) {
			idleState = false;
			anim.SetTrigger ();
		}
		// move back from the bar
		float originalDistance = Vector3.Distance (
			                         transform.position,
			                         originalPosition);
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
			anim.Idle ();
			idleState = true;
			Debug.Log ("Done drinking!");
			actionEnded = true;
		}
	}

	private void goToBar ()
	{
		if (idleState) {
			idleState = false;
	
		}
		float distance = absDistance (transform.position,
			                 finalObjective.transform.position);

		if (distance > maxDistance) {
			// Only move when not at the bar
			transform.position = new Vector3 (
				transform.position.x,
				transform.position.y,
				transform.position.z + speed
			);
		} else {
			anim.Idle ();
			idleState = true;
		}
	}

	private float absFloat (float a)
	{
		return a > 0 ? a : -a;
	}

	private void leaveBar ()
	{
		if (idleState) {
			Debug.Log ("Leaving the bar");
			idleState = false;
		}
		// leave the bar (go to the door)
		transform.position = Vector3.MoveTowards (transform.position,
			doorPosition, absFloat (speed) * Time.deltaTime * 100);
		
		if (transform.position == doorPosition) {
			Destroy (gameObject);
		}
	}
}