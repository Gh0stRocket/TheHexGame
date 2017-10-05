//Auf Defence selbst - Prefab

using UnityEngine;

public class Defence : Building {

	[Header("Defence specifics")]
	public float startRange = 1f;
	public float damagePerSec = 1f;
//	public GameObject rangeIndicator;
	[HideInInspector]
	public string meteorTag = "Meteor";
	[HideInInspector]
	public Transform partToRotate;
	public float turnSpeed = 10f;
	public Transform firePoint;
	[HideInInspector]
	public float range;
	[HideInInspector]
	public Transform target;
	[HideInInspector]
	public Meteor targetMeteor;
	[HideInInspector]
	public LineRenderer lineRenderer;
//	public ParticleSystem impactEffect;

	//19.09.17 - movement - n
	private Transform wheel1;
	private Transform wheel2;
	private Transform canon;


	void Start () {
		//19.09.17 - movement - n
		partToRotate = transform.Find ("tower_main");
		wheel1 = partToRotate.Find ("tower_zahnrad1");
		wheel2 = partToRotate.Find ("tower_zahnrad2");
		canon = partToRotate.Find ("kanonen_rohr");

		range = startRange;
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.enabled = false;
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

//	public void SetRangeIndicatorOn () {
//		rangeIndicator.SetActive (true);
//	}
//
//	public void SetRangeIndicatorOff () {
//		rangeIndicator.SetActive (false);
//	}

	void LockOnTarget () {	
//		Vector3 dir = target.position - transform.position;
//		Quaternion lookRotation = Quaternion.LookRotation (dir);
//		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
//		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
					
		Vector3 dir = target.position - partToRotate.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);

		Vector3 rotation = Quaternion.Slerp (partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
		wheel1.rotation = Quaternion.Euler (rotation.y, rotation.y, rotation.z);
		wheel2.rotation = Quaternion.Euler (-rotation.y, rotation.y, rotation.z);
		canon.rotation = lookRotation * Quaternion.Euler (90f, 0f, 0f);
	}

	void Laser () {
		targetMeteor.SubHitPoints (damagePerSec * Time.deltaTime);
		targetMeteor.hitPoints -= damagePerSec * Time.deltaTime;
		if (!lineRenderer.enabled) {			
			lineRenderer.enabled = true;
//			impactEffect.Play ();
		}	
		lineRenderer.SetPosition (0, firePoint.position);
		lineRenderer.SetPosition (1, target.position);
		Vector3 dir = firePoint.position - target.position;
//		impactEffect.transform.position = target.position + dir.normalized * 0.25f;
//		impactEffect.transform.rotation = Quaternion.LookRotation (dir);
	}

//void OnDrawGizmosSelected () {
//		Gizmos.color = Color.red;
//		Gizmos.DrawWireSphere(transform.position, range);
//	}

	void UpdateTarget(){
		GameObject[] meteors = GameObject.FindGameObjectsWithTag (meteorTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestMeteor = null;
		foreach (GameObject meteor in meteors) {
			float distanceToEnemy = Vector3.Distance (transform.position, meteor.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestMeteor = meteor;
			}
		}
		if (nearestMeteor != null && shortestDistance <= range) {
			target = nearestMeteor.transform;
			targetMeteor = nearestMeteor.GetComponent<Meteor> ();
		} else {
			target = null;
		}
	}

	void Update () {
		if (target == null) {
			if (lineRenderer.enabled) {
				lineRenderer.enabled = false;
//				impactEffect.Stop ();
			}
			return;
		}
		LockOnTarget ();
		Laser ();
	}
}