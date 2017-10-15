using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Spawner : MonoBehaviour {
	public GameObject[] attackerPrefabArray;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn(thisAttacker);
			}
		}
	}

	bool isTimeToSpawn(GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent <Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		} else {
			if (Random.value < spawnsPerSecond * Time.deltaTime / 5) {
				return true;
			}
		}
		return false;
	}

	void Spawn(GameObject attacker) {
		GameObject myAttacker = Instantiate (attacker) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
}
