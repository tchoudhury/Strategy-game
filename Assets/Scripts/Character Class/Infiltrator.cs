using UnityEngine;
using System.Collections;

public class Infiltrator : Unit {

	public Infiltrator(){
		characterClass = BaseClass.Assault;
		health = 60;
		speed = 14;
		actionPoint = 14;
		vision = 4;
		attraction = 5;
		accuracy = 0.65;
		ability = null;
	}
}
