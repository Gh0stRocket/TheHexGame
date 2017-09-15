//Auf die Mine selbst - Prefab

using UnityEngine;

public class Mine : Building {

	[Header("Mine specifics")]
	public float resourcesPerSec = 1f;

	void Update () {
		PlayerResources.IncreaseAmountOfResource ((resourcesPerSec * Time.deltaTime), hexagonParent.biome.resourceType);
	}
}