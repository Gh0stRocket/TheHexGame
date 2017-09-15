using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PrefabSpawner))]
public class PrefabSpawnerInspector : Editor {


	
	public override void OnInspectorGUI(){
		
		base.OnInspectorGUI ();

		PrefabSpawner pS = (PrefabSpawner)target; //PrefabSpawner pS = target as PrefabSpawner;

		if (GUILayout.Button ("Instantiate Prefabs")) {
			pS.InstantiatePrefabs ();
		}

		if (GUILayout.Button ("Delete all Prefabs")) {
			pS.DeletePrefabs ();
		}
	}
}
