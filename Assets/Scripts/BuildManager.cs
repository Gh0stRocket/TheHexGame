//Auf "BuildManager" - UI.Canvas.Panel

using UnityEngine;

public class BuildManager : MonoBehaviour {

	public GameObject mineMountain;
	public GameObject mineSand;
	public GameObject mineOil;
	public GameObject defence;
	[HideInInspector]
	public bool mineSelected;
	[HideInInspector]
	public GameObject buildingToBuild;
	[HideInInspector]
	public Hexagon hexagonToBuildOn;

	//Mouseimage
	[HideInInspector]
	public MouseController mouseController;

	void Start () {
		ClearBuildingSelection ();
		mouseController = GameObject.Find ("MouseController").GetComponent<MouseController> ();
	}
		
	public void SelectMineToBuild () {
		Debug.Log ("selected mine");
		ClearBuildingSelection ();
		mineSelected = true;
//		if (mouseController != null) {
//			mouseController.SetCursorTextureToMine ();
//		}
	}
	public void SelectDefenceToBuild () {
		ClearBuildingSelection ();
		buildingToBuild = defence;
//		if (mouseController != null) {
//			mouseController.SetCursorTextureToDefence ();
//		}
	}

	public void ClearBuildingSelection () {
		buildingToBuild = null;
		mineSelected = false;
	}

	public void BuildBuilding (int biomeID) {
		Vector3 pos = hexagonToBuildOn.TowerPosition.transform.position;
		if (mineSelected) {
			pos = hexagonToBuildOn.positionToPlace.transform.position;
			switch (biomeID) {
			case 1:
				buildingToBuild = mineMountain;
				break;
			case 2:
				buildingToBuild = mineOil;
				break;
			case 3:
				buildingToBuild = mineSand;
				break;
			default:
				break;
			}
		}
		Building b = buildingToBuild.GetComponent<Building> ();
		if (b.CanPay ()) {
			GameObject building = (GameObject) Instantiate (buildingToBuild, pos, Quaternion.identity);
			building.transform.parent = hexagonToBuildOn.transform;
			PlayerResources.DecreaseAmountOfResource (b.t1aCost, 1);
			PlayerResources.DecreaseAmountOfResource (b.t1bCost, 2);
			PlayerResources.DecreaseAmountOfResource (b.t1cCost, 3);
			if (mineSelected) {
				building.GetComponent<Mine> ().hexagonParent = hexagonToBuildOn;
				hexagonToBuildOn.buildingOnIt = buildingToBuild;
			}
			if (buildingToBuild == defence) {
				building.GetComponent<Defence> ().hexagonParent = hexagonToBuildOn;
				hexagonToBuildOn.buildingOnIt = buildingToBuild;
			}
		} else {
			Debug.Log ("Not enough resources");
		}
		ClearBuildingSelection ();
	}
}