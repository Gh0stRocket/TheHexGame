using UnityEngine;

public class HexaPrefabSetter : MonoBehaviour {

	public int biomeID = 1;
	[HideInInspector]
	public int spawnID;

	public bool isFirstRing = false;

	public GameObject prefab1, prefab2, prefab3;

	// Use this for initialization
	void Awake () {
		switch (biomeID)
		{
		case 1:
			GameObject prefab = Instantiate (prefab1, transform.position, Quaternion.identity);
			prefab.transform.parent = transform.parent;
			prefab.name = this.name;
			if (isFirstRing) {
				prefab.GetComponent<HexagonMovement> ().enabled = false;
			}
			break;
		case 2:
			prefab = Instantiate (prefab2, transform.position, Quaternion.identity);
			prefab.transform.parent = transform.parent;
			prefab.name = this.name;
			if (isFirstRing) {
				prefab.GetComponent<HexagonMovement> ().enabled = false;
			}
			break;
		case 3:
			prefab = Instantiate (prefab3, transform.position, Quaternion.identity);
			prefab.transform.parent = transform.parent;
			prefab.name = this.name;
			if (isFirstRing) {
				prefab.GetComponent<HexagonMovement> ().enabled = false;
			}
			break;
		default:
			break;
		}
	}

	void Start () {
		Destroy (gameObject);
	}
}