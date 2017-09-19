using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThrowObjectWithScore : MonoBehaviour {

	public AudioClip whoaSound;

	public UnityEvent OnPickUp;
	public UnityEvent On

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PickUpEvent(){
		OnPickUp.Invoke ();
		AudioSource.PlayClipAtPoint (whoaSound, transform.position);
	}



}
