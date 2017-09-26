using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent (typeof(AudioSource))]
[RequireComponent (typeof(Texture2D[]))]
public class MyVideoPlayer : MonoBehaviour
{
	private int currentImage = 0;
	private double timePassed = 0.0f;
	private Renderer renderer;


	public float delta = 0.2f;
	public Texture2D[] frames;
	public String shaderName;
	public String textureName;
	public AudioClip music;

	// Use this for initialization
	void Start ()
	{
		updateFrame ();
		renderer = GetComponent <Renderer> ();
		renderer.material.shader = Shader.Find (shaderName);
		AudioSource.PlayClipAtPoint (music, transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		timePassed += Time.deltaTime;
		if (timePassed > delta) {
			timePassed = 0.0f;
			updateFrame ();
		}
	}

	private void updateFrame ()
	{
		int i = currentImage % frames.Length;
		renderer.material.SetTexture (textureName, frames [i]);
		currentImage++;
	}
}
