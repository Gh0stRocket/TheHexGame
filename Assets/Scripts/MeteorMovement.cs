//Auf Meteor - Prefab mit Tag "Meteor"

using UnityEngine;

[RequireComponent(typeof(Meteor))]
public class MeteorMovement : MonoBehaviour {

	private Meteor meteor;
	public MeteorSpawner mS;
	private GameObject meteorTarget;

	void Start () {
		meteor = GetComponent<Meteor> ();
		mS = GameObject.Find("MeteorController").GetComponent<MeteorSpawner> ();

		//25.09.17 uebergibt das target damit jeder meteor ein eigenes hat
		meteorTarget = mS.meteorTarget;
	}
		
	void ReachesTarget () {			
		GameObject hexToDeactivate = meteorTarget;
		meteorTarget.GetComponent<HexagonMovement> ().isDestroyed = true;
		meteor.Die ();
	}

	void Update () {
		if (meteorTarget != null) {
			Vector3 dir = meteorTarget.transform.position - transform.position;
			transform.Translate (dir.normalized * meteor.speed * Time.deltaTime);
			if (Vector3.Distance (transform.position, meteorTarget.transform.position) <= 0.1) {
				ReachesTarget ();
			}
		} else {
			meteor.Die ();
		}
	}
}