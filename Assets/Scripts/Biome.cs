//Auf ein Hexagon - Prefab

using UnityEngine;

public class Biome : MonoBehaviour {

	public float resourceStock = 100f;
	public int biomeType;
	[HideInInspector]
	public int resourceType;

	void Start () {
		switch (biomeType)
		{
		case 1:
			resourceType = 1;
			break;
		case 2:
			resourceType = 2;
			break;
		case 3:
			resourceType = 3;
			break;
		default:
			break;
		}		
	}
}