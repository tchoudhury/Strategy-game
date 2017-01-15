using UnityEngine;
using System.Collections;

public class Support : Unit {

	public Support(){
		characterClass = BaseClass.Assault;
		health = 85;
		speed = 8;
		actionPoint = 10;
		vision = 5;
		attraction = 6;
		accuracy = 0.55;
		ability = null;
	}
}
