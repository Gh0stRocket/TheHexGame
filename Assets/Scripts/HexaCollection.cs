using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaCollection : MonoBehaviour {

	public Transform [] hexArray;//hexagons in array
	public GameObject hexSpawner;
	private int hexCount;

	public float hexSpeed = 10f;

	public float pullTimer = 1f;

	// Use this for initialization
	void Start () {
		hexCount = hexSpawner.transform.childCount;
		hexArray = new Transform[hexCount];

		for (int i = 0; i < hexArray.Length; i++) {
			hexArray [i] = hexSpawner.transform.GetChild (i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		pullTimer -= Time.deltaTime;

		if (pullTimer <= 0) {
			
			for( int activeHex = 0; hexArray.Length > activeHex; activeHex++){
				if (hexArray [activeHex].GetComponent<HexagonMovement> ().speed == 0f && !hexArray [activeHex].GetComponent<HexagonMovement> ().isLocked) {
					hexArray [activeHex].GetComponent<HexagonMovement> ().speed = hexSpeed;
					pullTimer = 1f;
					return;
				} 
			}
		}
	}
}
