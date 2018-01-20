using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Stack<Vector3> recentLocations;
	public Game gameMaster;

	
	AudioSource aud;

	// Use this for initialization
	void Start () {
		string[] devices = Microphone.devices;
		foreach(string d in devices) {
			Debug.Log(d);
		}
		aud = GetComponent<AudioSource>();
		aud.clip = Microphone.Start(null, true, 2, 44100);

		recentLocations = new Stack<Vector3>();
		recentLocations.Push(this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z)) {
			GoBack();
		} else if(Input.GetKeyDown(KeyCode.Q)) {
			GoTo("jars");
		} else if(Input.GetKeyDown(KeyCode.E)) {
			GoTo("instruments");
		} else if(Input.GetKeyDown(KeyCode.R)) {
			GoTo("desk");
		} else if(Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("is recording? " + Microphone.IsRecording(null));
			aud.Play();
		}
	}

	void GoTo(string name){
		Vector3 toGo = gameMaster.getLocationOfObject(name);
		Debug.Log("Going to " + toGo);
		if(recentLocations.Peek() != toGo) {
			this.transform.position = toGo;
			recentLocations.Push(toGo);
		}
	}

	void GoBack(){
		if(recentLocations.Count > 0){
			recentLocations.Pop();
			Vector3 top = recentLocations.Peek();
			Debug.Log("Going back to " + top);
			if(top != null) {
				this.transform.position = top;
			}
		}
	}
}
