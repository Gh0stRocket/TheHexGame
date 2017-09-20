//Auf Meteor - Prefab mit Tag "Meteor"

using UnityEngine;

[RequireComponent(typeof(Meteor))]
public class MeteorMovement : MonoBehaviour {

	private Meteor meteor;
	public MeteorSpawner mS;

	void Start () {
		meteor = GetComponent<Meteor> ();
		mS = GameObject.Find("MeteorController").GetComponent<MeteorSpawner> ();
	}
		
	void ReachesTarget () {			
		GameObject hexToDeactivate = mS.meteorTarget;
		mS.meteorTarget.GetComponent<HexagonMovement> ().isDestroyed = true;
		meteor.Die ();
	}

	void Update () {
		if (mS.meteorTarget != null) {
			Vector3 dir = mS.meteorTarget.transform.position - transform.position;
			transform.Translate (dir.normalized * meteor.speed * Time.deltaTime);
			if (Vector3.Distance (transform.position, mS.meteorTarget.transform.position) <= 0.1) {
				ReachesTarget ();
			}
		}
	}
}