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
		
	public void SubHitPoints (float amount) {
		hitPoints -= amount;
		if (hitPoints <= 0) {
			Die ();
		}
	}

	public void Die () {
		GameObject effect = (GameObject) Instantiate (deathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 1.1f);
		Destroy (gameObject);
	}
}