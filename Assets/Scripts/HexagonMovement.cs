//Auf Hexagon - Prefab

using UnityEngine;

[RequireComponent(typeof(Hexagon))]
public class HexagonMovement : MonoBehaviour {

	[HideInInspector]
	public GameObject target;
	public Vector3 targetVector;
	public float speed = 4f;
	private float dockingSpeed = 3f;
	public Vector3 startPosition;
	public bool isLocked = false;
	public bool isDestroyed = false;

	void Start () {
		startPosition = transform.position;
		target = GameObject.Find ("Hexagon0|0");
		Vector3 dir = target.transform.position - transform.position;
		transform.Translate (-dir.normalized * 50);
		speed = 0f;
	}

	void Update () {
		Vector3 dir = startPosition - transform.position;
		if (Vector3.Distance (startPosition, transform.position) >= 5f) {
			transform.Translate (dir.normalized * speed * Time.deltaTime);
		} else if (Vector3.Distance (startPosition, transform.position) >= 0.1f) {
			transform.Translate (dir.normalized * dockingSpeed * Time.deltaTime);
		} else {
			isLocked = true;
			speed = 0f;
			transform.position = startPosition;
		}

		if (isDestroyed) {
			gameObject.SetActive(false);
		}
	}
}