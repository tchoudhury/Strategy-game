using UnityEngine;
using System.Collections;

public class Assault : Unit {

	public Assault(){
		characterClass = BaseClass.Assault;
		health = 100;
		speed = 12;
		actionPoint = 10;
		vision = 5;
		attraction = 10;
		accuracy = 0.75;
		ability = null;
	}

}