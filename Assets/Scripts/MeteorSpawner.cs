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

	//Index der Wave
	private int waveID = 0;

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

		//Exception
		if (!IsObjectInArray () || meteorTargetArray.Length <= 0) {
			Debug.Log ("ausstieg aus Find Target!");
			return;
		}
		randomMeteorPicker = Random.Range (0, meteorTargetArray.Length);
		Debug.Log ("Meteor looking for target");
		meteorTarget = meteorTargetArray [randomMeteorPicker].gameObject;
		meteorSpawnPoint = new Vector3(meteorTargetArray [randomMeteorPicker].transform.position.x, meteorTargetArray [randomMeteorPicker].transform.position.y + 20, meteorTargetArray [randomMeteorPicker].transform.position.z);
		Debug.Log(meteorTargetArray [randomMeteorPicker]);
		return;
	}

	IEnumerator SpawnWave () {
		//scaling
		waveID ++;
		int scaleVal = (int) Mathf.Round (1 + waveID / 10);
//		Debug.Log (scaleVal);
		for (int i = 0; i < scaleVal; i++) {
			FindTargetHex ();
			SpawnMeteor (meteorPrefab, 1);
			yield return new WaitForSeconds (timeBetweenMeteors);
		}
		yield return new WaitForSeconds (0.0f);
	}

	void SpawnMeteor (Transform meteor, float amount) {
		//Exception
		if (!IsObjectInArray () || meteorTargetArray.Length <= 0) {
			Debug.Log ("ausstieg aus Spawn!");
			return;
		}
		Transform spawnedEnemy = Instantiate (meteor, meteorSpawnPoint, Quaternion.identity);
	}

	//19.09.17 - Exception - n
	public bool IsObjectInArray () {
		for (int i = 0; i < meteorTargetArray.Length; i++) {
			if (meteorTargetArray [i] != null) {
				return true;
			}
		}
		return false;
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
			
			StartCoroutine (SpawnWave ());
			meteorTimer = timeBetweenWaves;
		}
		meteorTimer -= Time.deltaTime;
	}
}