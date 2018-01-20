using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public Stage[] stages {
		get; set;
	}

	public InteractiveObject[] interactiveObjects;

	public Stage CurrentStage {
		get {
			for(int i = 0; i < stages.Length; i++) {
				if(stages[i].isAvailable && !stages[i].isCompleted) return stages[i];
			}
			return new Stage(null, -1, "Game Over");
		}
	}

	// Use this for initialization
	void Start () {
		Stage s1 = new Stage(null, 2, "Stage 1");
		Stage s2 = new Stage(new Stage[] {s1}, 3, "Stage 2");
		Stage s3 = new Stage(new Stage[] {s1, s2}, 3, "Stage 3");

		stages = new Stage[] { s1, s2, s3 };
		for(int i = 0; i < stages.Length; i++){
			Debug.Log(stages[i]);
		}
	}
	
	public InteractiveObject mapNameToObject(string name) {
		for(int i = 0; i < interactiveObjects.Length; i++){
			InteractiveObject obj = interactiveObjects[i];
			for(int j = 0; j < obj.names.Length; j++){
				if(obj.names[j] == name) return obj;
			}
		}
		return null;
	}

	public Vector3 getLocationOfObject(string name) {
		InteractiveObject obj = mapNameToObject(name);
		if(obj != null) {
			return obj.placementPot.position;
		}
		return Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
