using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlayerPrefManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (volumeSlider.value);
	}

	public void SaveAndExit() {
		PlayerPrefManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefManager.SetDifficulty (difficultySlider.value);
		levelManager.LoadLevel ("01a Start");
	}

	public void SetDefault() {
		volumeSlider.value = 1f;
		difficultySlider.value = 2f;
	}
}
