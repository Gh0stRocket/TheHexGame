//Auf Master - Empty GameObject

using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public Transform meteorPrefab;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5.5f;
	public float timeBetweenMeteors = 0.5f;
	public float meteorTimer = 10f;

	public HexaCollection hexC;
	public GameObject meteorTarget;
	public Vector3 meteorSpawnPoint;

	public Transform [] meteorTargetArray;
	private int availableTargets;
	private int randomMeteorPicker;
	private int filledArrayLength;

	public int lockedHexCount;

	void Start(){
	}

	void FindTargetHex() {
		for (int i = 0; hexC.hexArray.Length > i; i++) {
			if (hexC.hexArray [i].GetComponent<HexagonMovement> ().isLocked) {
				lockedHexCount += 1;
			}
		}
		meteorTargetArray = new Transform[lockedHexCount];

		lockedHexCount = 0;

		for (int i = 0; hexC.hexArray.Length > i; i++) {
			if (hexC.hexArray [i].GetComponent<HexagonMovement> ().isLocked && !hexC.hexArray [i].GetComponent<HexagonMovement> ().isDestroyed) {
				meteorTargetArray [i] = hexC.hexArray[i];
			}
		}

//		for (int i = 0; i < meteorTargetArray.Length; i++) {
//			if (meteorTargetArray [i] != null) {
//				filledArrayLength += 1;
//			}
//		}
		randomMeteorPicker = Random.Range (0, meteorTargetArray.Length);
		Debug.Log ("Meteor looking for target");
		meteorTarget = meteorTargetArray [randomMeteorPicker].gameObject;
		meteorSpawnPoint = new Vector3(meteorTargetArray [randomMeteorPicker].transform.position.x, meteorTargetArray [randomMeteorPicker].transform.position.y + 20, meteorTargetArray [randomMeteorPicker].transform.position.z);
		Debug.Log(meteorTargetArray [randomMeteorPicker]);
		return;
	}

	IEnumerator SpawnWave () {
		for (int i = 0; i < 1; i++) {
			SpawnEnemy (meteorPrefab, 1);
			yield return new WaitForSeconds (timeBetweenMeteors);
		}
		yield return new WaitForSeconds (0.0f);
	}

	void SpawnEnemy (Transform enemy, float amount) {
		Transform spawnedEnemy = Instantiate (enemy, meteorSpawnPoint, Quaternion.identity);
	}

	void Update () {

//		if (hexC.hexArray.Length != 0) {
//			meteorTargetArray = new Transform[hexC.hexArray.Length];
//		}
//
//		for (int i = 0; hexC.hexArray.Length > i; i++) {
//			if (hexC.hexArray [i].GetComponent<HexagonMovement> ().isLocked && !hexC.hexArray [i].GetComponent<HexagonMovement> ().isDestroyed) {
//				meteorTargetArray [i] = hexC.hexArray[i];
//			}
//		}
		
		if (meteorTimer <= 0f) {
			FindTargetHex ();
			StartCoroutine (SpawnWave ());
			meteorTimer = timeBetweenWaves;
		}
		meteorTimer -= Time.deltaTime;
	}
}