using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range(-1f,1.5f)]
	public float currentSpeed;
	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidBody.isKinematic = true;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (currentTarget == null) {
			animator.SetBool("isAttacking", false);
		}
	}

	void OnTriggerEnter2D() {
		
	}
		
	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}

	//called from the animator at time of actual flow
	public void StrikeCurrentTarget(float damage) {
		if (currentTarget != null) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health != null) {
				health.DealDamage(damage);
			}
		}
	}

	public void Attack(GameObject obj) {
		currentTarget = obj;

	}

	

}
