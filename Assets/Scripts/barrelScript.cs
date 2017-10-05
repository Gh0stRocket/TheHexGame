using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelScript : MonoBehaviour {

//	public laserscript laserScript;
	public GameObject lineParticles;
	public ParticleSystem pointParticles;
	public ParticleSystem zoomParticles;


	//QuaternionShit
	public Transform target;
	public float turnSpeed = 1f;
	private Quaternion tmpRotation;
	public Vector3 targetPointBarrels;
	private Quaternion targetRotationTurret;
	private Quaternion targetRotationBarrels;
	private Transform wheel1;
	private Transform wheel2;
	private static Vector3 leadTargetPosition;
	private Vector3 targetPointTurret;
	private Transform parent;
	private GameObject canon;


	void Start () {
		parent = transform.Find ("tower_main");
		canon = GameObject.FindWithTag ("rohr");
		wheel1 = transform.Find ("tower_zahnrad1");
		wheel2 = transform.Find ("tower_zahnrad2");


		lineParticles = GameObject.Find ("laserstart");
		pointParticles = transform.Find ("kanonen_rohr").Find ("laserstart").GetComponent<ParticleSystem> ();
		zoomParticles = transform.Find ("kanonen_rohr").Find ("Particle System").GetComponent<ParticleSystem> ();


	}
	
	// Update is called once per frame
	void Update () {
		SetTarget ();

		if (target != null) {
			tmpRotation = transform.localRotation;
//			leadTargetPosition = new Vector3(Intercept.FirstOrderIntercept (transform.position, Vector3.zero, pScript.partVelo.z, target.transform.position, rbVelocity));
			Vector3 dir = (target.position - transform.position).normalized;
			targetRotationTurret = Quaternion.LookRotation (dir);
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotationTurret, Time.deltaTime * turnSpeed);
			transform.localRotation = Quaternion.Euler (tmpRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, tmpRotation.eulerAngles.z);
			wheel1.rotation = Quaternion.Euler (transform.localRotation.eulerAngles.y,tmpRotation.eulerAngles.y,tmpRotation.eulerAngles.z);
			wheel2.rotation = Quaternion.Euler (-transform.localRotation.eulerAngles.y, tmpRotation.eulerAngles.y, tmpRotation.eulerAngles.z);


			tmpRotation = canon.transform.localRotation;
			Vector3 dirr = (target.position - canon.transform.position).normalized;
			targetRotationBarrels = Quaternion.LookRotation (dirr) * Quaternion.Euler (90f, 0f, 0f);
			canon.transform.rotation = Quaternion.Slerp (canon.transform.rotation, targetRotationBarrels, Time.deltaTime * turnSpeed);
			canon.transform.localRotation = Quaternion.Euler (canon.transform.localRotation.eulerAngles.x, tmpRotation.eulerAngles.y, tmpRotation.eulerAngles.z);
	
		}
	}



	void SetTarget () {
//		GameObject[] meteors = GameObject.FindGameObjectsWithTag ("meteor");
//		float shortestDistance = Mathf.Infinity;
//		GameObject nearestMeteor = null;
//		foreach (GameObject meteor in meteors) {
//			float distanceToEnemy = Vector3.Distance (transform.position, meteor.transform.position);
//			if (distanceToEnemy < shortestDistance) {
//				shortestDistance = distanceToEnemy;
//				nearestMeteor = meteor;
//			}
//		}
//		if (nearestMeteor != null && shortestDistance <= 10) {
//			target = nearestMeteor.transform;
//			laserScript.enabled = true;
//			laserScript.laserLine.enabled = true;
//			laserScript.endPoint = target;
//			lineParticles.SetActive (true);
//			zoomParticles.Play ();
//		} else {
//			laserScript.laserLine.enabled = false;
//			laserScript.enabled = false;
//			lineParticles.SetActive (false);
//			zoomParticles.Stop ();
//			target = null;
//		}
	}
}
