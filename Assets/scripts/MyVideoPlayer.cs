using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Video;

//[RequireComponent (typeof(VideoClip))]
//[RequireComponent (typeof(AudioSource))]
//[RequireComponent (typeof(Texture2D[]))]
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;


public class MyVideoPlayer : MonoBehaviour
{
	private int currentImage = 0;
	private double timePassed = 0.0f;
	private Renderer renderer;

	public RawImage image;

	public float delta = 0.2f;
	public Texture2D[] frames;
	public String shaderName;
	public String textureName;
	public AudioClip music;

	private VideoPlayer videoPlayer;
	private VideoSource videoSource;
	private AudioSource audioSource;
	public VideoClip videoClip;


	// Use this for initialization
	void Start ()
	{
//		updateFrame ();
//		AudioSource.PlayClipAtPoint (music, transform.position);
		StartCoroutine (playVideo ());
	}
	
	// Update is called once per frame
	void Update ()
	{
//		timePassed += Time.deltaTime;
//		if (timePassed > delta) {
//			timePassed = 0.0f;
//			updateFrame ();
//		}
	}

	private IEnumerator playVideo ()
	{
		videoPlayer = gameObject.AddComponent<VideoPlayer> ();
		audioSource = gameObject.AddComponent<AudioSource> ();

		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;
		audioSource.Pause ();

		videoPlayer.source = VideoSource.VideoClip;

		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

		videoPlayer.EnableAudioTrack (0, true);
		videoPlayer.SetTargetAudioSource (0, audioSource);

		videoPlayer.clip = videoClip;
		videoPlayer.Prepare ();

		// wait while video is prepared
		WaitForSeconds waitTime = new WaitForSeconds (1);
		while (!videoPlayer.isPrepared) {
			Debug.Log ("Preparing");
			yield return waitTime;
			break;
		}

		image.texture = videoPlayer.texture;

		videoPlayer.Play ();
		audioSource.Play ();
	}
}
