//Auf ein Hexagon - Prefab

using UnityEngine;
using UnityEngine.EventSystems;

public class Hexagon : MonoBehaviour {

	//	public int resourceAmount;
	[HideInInspector]
	public Biome biome;
	[HideInInspector]
	public GameObject buildingOnIt;
//	[HideInInspector]
//	public GameObject positionToPlace;
//	public GameObject TowerPosition;
	[HideInInspector]
	public BuildManager buildManager;

	//17.09.17 - n
	public GameObject defenceBuilding;
	public GameObject mineBuilding;

	public bool isLockedExtra = false;

	void Start () {
//		positionToPlace = gameObject;
		biome = GetComponent<Biome> ();
		buildManager = GameObject.Find ("BuildManager").GetComponent<BuildManager> ();

		//17.09.17 - n
		defenceBuilding = transform.Find("Defence").gameObject;
		mineBuilding = transform.Find("Mine").gameObject;
	}
		
	void OnMouseDown () {
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		//Damit man ihn beim Anflug nicht bebauen kann
		if (!isLockedExtra) {
			return;
		}
		buildManager.hexagonToBuildOn = this;
		if (buildingOnIt == null) {
			//17.09.17 - Veraltet - n
//			if (!buildManager.mineSelected && buildManager.buildingToBuild == null) {
//				return;
//			}
			buildManager.BuildBuilding (biome.biomeType);
		}
	}

	public void EnableMine () {
		mineBuilding.SetActive (true);
	}

	public void EnableDefence () {
		defenceBuilding.SetActive (true);
	}
}