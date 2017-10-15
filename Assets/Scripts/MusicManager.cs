using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake() {
		DontDestroyOnLoad (gameObject);
		SceneManager.sceneLoaded += LevelLoaded;
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = PlayerPrefManager.GetMasterVolume ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	void LevelLoaded(Scene scene, LoadSceneMode mode) {
		AudioClip musicChange = levelMusicChangeArray[SceneManager.GetActiveScene().buildIndex];
		if (musicChange) {
			audioSource.clip = musicChange;
			audioSource.loop = true;
			audioSource.volume = PlayerPrefManager.GetMasterVolume ();
			audioSource.Play();
		}
	}

	public void ChangeVolume(float value) {
		audioSource.volume = value;
	}
}
