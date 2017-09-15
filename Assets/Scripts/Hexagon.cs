//Auf ein Hexagon - Prefab

using UnityEngine;
using UnityEngine.EventSystems;

public class Hexagon : MonoBehaviour {

	//	public int resourceAmount;
	[HideInInspector]
	public Biome biome;
	[HideInInspector]
	public GameObject buildingOnIt;
	[HideInInspector]
	public GameObject positionToPlace;
	public GameObject TowerPosition;
	[HideInInspector]
	public BuildManager buildManager;

	void Start () {
		positionToPlace = gameObject;
		biome = GetComponent<Biome> ();
		buildManager = GameObject.Find ("BuildManager").GetComponent<BuildManager> ();
	}
		
	void OnMouseDown () {
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		buildManager.hexagonToBuildOn = this;
		if (buildingOnIt == null) {
			if (!buildManager.mineSelected && buildManager.buildingToBuild == null) {
				return;
			}
			buildManager.BuildBuilding (biome.biomeType);
		}
	}		
}