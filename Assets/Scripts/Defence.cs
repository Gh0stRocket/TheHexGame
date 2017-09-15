//Auf Defence selbst - Prefab

using UnityEngine;

public class Defence : Building {

	[Header("Defence specifics")]
	public float startRange = 1f;
	public float damagePerSec = 1f;
	public GameObject rangeIndicator;
	public string meteorTag = "Meteor";
	public Transform partToRotate;
	public float turnSpeed = 10f;
	public Transform firePoint;
//	[HideInInspector]
	public float range;
	public Transform target;
	public Meteor targetMeteor; 
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect; 

	void Start () {
		range = startRange;

		lineRenderer.enabled = false;
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	public void SetRangeIndicatorOn () {
		rangeIndicator.SetActive (true);
	}

	public void SetRangeIndicatorOff () {
		rangeIndicator.SetActive (false);
	}

	void LockOnTarget () {	
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
	}

	void Laser () {
//		targetMeteor.SubHitPoints (damagePerSec * Time.deltaTime);
		targetMeteor.hitPoints -= damagePerSec * Time.deltaTime;
		if (!lineRenderer.enabled) {			
			lineRenderer.enabled = true;
			impactEffect.Play ();
		}	
		lineRenderer.SetPosition (0, firePoint.position);
		lineRenderer.SetPosition (1, target.position);
		Vector3 dir = firePoint.position - target.position;
		impactEffect.transform.position = target.position + dir.normalized * 0.25f;
		impactEffect.transform.rotation = Quaternion.LookRotation (dir);
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

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
				impactEffect.Stop ();
			}
			return;
		}
		LockOnTarget ();
		Laser ();
	}
}