using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	public float speed;
	public float maxDistance;

	public GameObject finalObjective;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		float distance = Vector3.Distance (transform.position,
			                 finalObjective.transform.position);
		distance = distance > 0 ? distance : -distance;  // abs

//		if (distance > maxDistance)
		// Only move when not at the bar
		transform.position = new Vector3 (
			transform.position.x,
			transform.position.y,
			transform.position.z + speed
		);

	}
}