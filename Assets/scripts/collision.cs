using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {

	public AudioClip breakGlass;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter(Collision col)
	{
		AudioSource.PlayClipAtPoint (breakGlass, transform.position);
	}
}
