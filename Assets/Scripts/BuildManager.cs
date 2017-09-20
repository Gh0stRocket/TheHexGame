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
	public bool defenceSelected;
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
		Debug.Log ("selected def");
		ClearBuildingSelection ();
		defenceSelected = true;
//		buildingToBuild = defence;
//		if (mouseController != null) {
//			mouseController.SetCursorTextureToDefence ();
//		}
	}

	public void ClearBuildingSelection () {
		buildingToBuild = null;
		mineSelected = false;
		defenceSelected = false;
	}

	//17.09.17 - Reworked Buildingfunction - n
	public void BuildBuilding (int biomeID) {
		if (mineSelected) {
			buildingToBuild = hexagonToBuildOn.mineBuilding;
		}
		if (defenceSelected) {
			buildingToBuild = hexagonToBuildOn.defenceBuilding;
		}
		Building b = buildingToBuild.GetComponent<Building> ();
		if (b.CanPay ()) {
			PlayerResources.DecreaseAmountOfResource (b.t1aCost, 1);
			PlayerResources.DecreaseAmountOfResource (b.t1bCost, 2);
			PlayerResources.DecreaseAmountOfResource (b.t1cCost, 3);
			if (mineSelected) {
				hexagonToBuildOn.EnableMine ();
				GameObject building = hexagonToBuildOn.mineBuilding;
				building.GetComponent<Mine> ().hexagonParent = hexagonToBuildOn;
				hexagonToBuildOn.buildingOnIt = buildingToBuild;
			} else {
				hexagonToBuildOn.EnableDefence ();
				GameObject building = hexagonToBuildOn.defenceBuilding;
				building.GetComponent<Defence> ().hexagonParent = hexagonToBuildOn;
				hexagonToBuildOn.buildingOnIt = buildingToBuild;
			}
		} else {
			Debug.Log ("Not enough resources");
		}
		ClearBuildingSelection ();
	}
}