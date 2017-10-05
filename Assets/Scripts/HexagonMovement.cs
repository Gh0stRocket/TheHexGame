//Auf Hexagon - Prefab

using UnityEngine;

[RequireComponent(typeof(Hexagon))]
public class HexagonMovement : MonoBehaviour {

	[HideInInspector]
	public GameObject target;
	public Vector3 targetVector;
	public float speed = 4f;
	private float dockingSpeed = 2f;
	public Vector3 startPosition;
	public bool isLocked = false;
	public bool isDestroyed = false;

	private Hexagon hexa;

	void Start () {
		hexa = GetComponent<Hexagon> ();
		startPosition = transform.position;
		target = GameObject.Find ("Hexagon0|0");
		Vector3 dir = target.transform.position - transform.position;
		transform.Translate (-dir.normalized * 100);
		speed = 0f;
	}

	void Update () {
		Vector3 dir = startPosition - transform.position;
		float dis = Vector3.Distance (startPosition, transform.position);
		if (dis >= 10f) {
			transform.Translate (dir.normalized * speed * 2 * Time.deltaTime);
		} else if (dis >= 5f) {
			transform.Translate (dir.normalized * speed * Time.deltaTime);
		} else if (dis >= 2f) {
			transform.Translate (dir.normalized * ((speed + dockingSpeed)/2) * Time.deltaTime);
		} else if (dis >= 0.1f) {
			transform.Translate (dir.normalized * dockingSpeed * Time.deltaTime);
		} else {
			isLocked = true;
			hexa.isLockedExtra = true;
			speed = 0f;
			transform.position = startPosition;
		}

		if (isDestroyed) {
			gameObject.SetActive(false);
		}
	}
}