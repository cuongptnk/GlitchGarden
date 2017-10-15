using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefManager : MonoBehaviour {
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	void Start() {
		if (!PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, 1f);
		}
		if (!PlayerPrefs.HasKey (DIFFICULTY_KEY)) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, 2f);
		}
	}

	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume is out or range");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level) {
		if (level <= SceneManager.sceneCountInBuildSettings) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(),1); // use 1 for true
		} else {
			Debug.LogError ("The index is out of level range");
		}
	}

	public static bool IsLevelUnlocked (int level) {
		if (level <= SceneManager.sceneCountInBuildSettings) {
			return (PlayerPrefs.GetInt (LEVEL_KEY+level.ToString()) == 1);
		} else {
			Debug.LogError ("The index is out of level range");
			return false;
		}
	}

	public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY,difficulty);
		} else {
			Debug.LogError ("Difficulty out of range");
		}
	}

	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
