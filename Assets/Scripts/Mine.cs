//Auf die Mine selbst - Prefab

using UnityEngine;

public class Mine : Building {

	[Header("Mine specifics")]
	public float resourcesPerSec = 1f;

	private Biome biome;

	void Start () {
		biome = GetComponentInParent<Biome> ();
	}

	void Update () {
		if (biome.resourceStock > 0) {
			PlayerResources.IncreaseAmountOfResource ((resourcesPerSec * Time.deltaTime), hexagonParent.biome.resourceType);
		}
	}
}