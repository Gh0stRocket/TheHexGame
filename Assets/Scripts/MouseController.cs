//Auf "MouseController" - Empty GameObject

using UnityEngine;

public class MouseController : MonoBehaviour {

	public Texture2D cursorTextureMine;
	public Texture2D cursorTextureDefence;
	[HideInInspector]
	public CursorMode cursorMode = CursorMode.Auto;
	[HideInInspector]
	public Vector2 hotSpot = Vector2.zero;

	public void SetCursorTextureToMine () {
		Cursor.SetCursor (cursorTextureMine, hotSpot, cursorMode);
	}
	public void SetCursorTextureToDefence () {
		Cursor.SetCursor (cursorTextureDefence, hotSpot, cursorMode);
	}

	public void SetCursorTExtureToDefault () {
		Cursor.SetCursor (null, hotSpot, cursorMode);
	}
}