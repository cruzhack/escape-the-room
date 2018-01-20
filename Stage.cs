using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage  {

	public Stage[] Required {
		get {
			return required;
		}
	}

	public bool isCompleted {
		get {
			return (requirements ^ checks) == 0; 
		}
	}

	public bool isAvailable {
		get {
			if(required == null) return true;
			for(int i = 0; i < required.Length; i++) {
				if(!required[i].isCompleted) return false;
			}
			return true;
		}
	}

	public InteractiveObject[] findableObjects {
		get; set;
	}

	public string Name {
		get; set;
	}

	private byte requirements = 0;
	private byte checks = 0;
	private Stage[] required;

	public Stage(Stage[] required, int requirementCount, string name = "STAGE") {
		this.required = required;
		for(int i = 0; i < requirementCount; i++) {
			this.requirements |= (byte) (1 << i);
		}
		this.Name = name;
	}

	public void CheckOff(int index){
		checks |= (byte) (1 << index);
	}

	public override string ToString(){
		return Name;
	}

}
