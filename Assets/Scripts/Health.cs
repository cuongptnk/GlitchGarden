using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DealDamage(float damage) {
		if (health > 0) {
			health -= damage;
		} else {
			//optinally trigger die animation
			DestroyObject();
		}
	}

	public void DestroyObject() {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
