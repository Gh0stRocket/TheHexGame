//Auf Meteor - Prefab mit Tag "Meteor"

using UnityEngine;

public class Meteor : MonoBehaviour {

	[HideInInspector]
	public float speed;
	[HideInInspector]
	public float hitPoints;

	public float startSpeed = 1.0f;
	public float startHitPoints = 1.0f;
	public GameObject deathEffect;


	void Start () {
		speed = startSpeed;
		hitPoints = startHitPoints;
	}

	void Update(){
		if (hitPoints <= 0) {
//			Die ();
			Destroy(gameObject);
		}
	}

//	public void SubHitPoints (float amount) {
//		hitPoints -= amount;
//		if (hitPoints <= 0) {
//			Die ();
//		}
//	}

	void Die () {
		GameObject effect = (GameObject) Instantiate (deathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 2.0f);
		Destroy (gameObject);
	}
}