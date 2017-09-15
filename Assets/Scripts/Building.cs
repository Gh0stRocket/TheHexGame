//Hilfsklasse

using UnityEngine;

public class Building : MonoBehaviour {

	[Header("Costs")]
	public int t1aCost = 0;
	public int t1bCost = 0;
	public int t1cCost = 0;
//	public int t2aCost = 0;
//	public int t2bCost = 0;
//	public int t2cCost = 0;

	[HideInInspector]
	public Hexagon hexagonParent;

	public bool CanPay () {
		if (t1aCost <= PlayerResources.t1aAmount && t1bCost <= PlayerResources.t1bAmount && t1bCost <= PlayerResources.t1bAmount) {
			return true;
		} else {
			return false;
		}
	}
}