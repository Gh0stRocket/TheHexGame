//Auf MASTER - Empty GameObject
//changed

using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour {

	public float startAmountT1a;
	public float startAmountT1b;
	public float startAmountT1c;

	public static float t1aAmount;
	public static float t1bAmount;
	public static float t1cAmount;

	//UI
	public Text t1aAmountText;
	public Text t1bAmountText;
	public Text t1cAmountText;
	public static Text _t1aAmountText;
	public static Text _t1bAmountText;
	public static Text _t1cAmountText;

	void Start () {
		_t1aAmountText = t1aAmountText;
		_t1bAmountText = t1bAmountText;
		_t1cAmountText = t1cAmountText;
		t1aAmount = startAmountT1a;
		t1bAmount = startAmountT1b;
		t1cAmount = startAmountT1c;
		UpdateResourceText ();
	}

	public static void IncreaseAmountOfResource (float amount, int resourceID) {
		switch (resourceID)
		{
		case 1:
			t1aAmount += amount;
			break;
		case 2:
			t1bAmount += amount;
			break;
		case 3:
			t1cAmount += amount;
			break;
		default:
			break;
		}
		UpdateResourceText ();
	}

	public static void DecreaseAmountOfResource (float amount, int resourceID) {
		switch (resourceID)
		{
		case 1:
			if (t1aAmount - amount >= 0) {
				t1aAmount -= amount;
			}
			break;
		case 2:
			if (t1bAmount - amount >= 0) {
				t1bAmount -= amount;
			}
			break;
		case 3:
			if (t1cAmount - amount >= 0) {
				t1cAmount -= amount;
			}
			break;
		default:
			break;
		}
		UpdateResourceText ();
	}

	public static void UpdateResourceText () {
		_t1aAmountText.text = "Iron " + Mathf.Round(t1aAmount) + " ";
		_t1bAmountText.text = "Oil " + Mathf.Round(t1bAmount) + " ";
		_t1cAmountText.text = "Glas " + Mathf.Round(t1cAmount) + " ";
	}

	void Update () {
		//Dauerhafter Energiebedarf (2) 
		DecreaseAmountOfResource (0.5f * Time.deltaTime, 1);
		DecreaseAmountOfResource (0.5f * Time.deltaTime, 2);
		DecreaseAmountOfResource (0.5f * Time.deltaTime, 3);

		//Vorerst GameExit
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}