using UnityEngine;
using System.Collections;

public class Sniper : Unit {

	public Sniper(){
		characterClass = BaseClass.Assault;
		health = 50;
		speed = 6;
		actionPoint = 10;
		vision = 4;
		attraction = 20;
		accuracy = 0.95;
		ability = null;
	}
}
