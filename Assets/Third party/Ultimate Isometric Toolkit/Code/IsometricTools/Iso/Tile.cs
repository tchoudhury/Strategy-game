using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

[RequireComponent(typeof(IsoObject))]
public class Tile : MonoBehaviour {

	public string name;
    public bool canBeReached = true;
	public float movementCost = 1;
	public GameObject tileVisualPrefab;
	public PathFinding pathFinder;

	private IsoObject obj;
	public HashSet<Tile> edges;
	public Tile parentNode;
	public float gCost, fCost, hCost;

    //wrap isoObj.position. comfort only
    public Vector3 Position {
        get {
            var isoObj = this.GetOrAddComponent<IsoObject>();
            return isoObj.Position; 
        }
        set {
            var isoObj = this.GetOrAddComponent<IsoObject>();
            isoObj.Position = value; 
        }
    }

    public Vector3 Size {
        get {
            var isoObj = this.GetOrAddComponent<IsoObject>();
            return isoObj.Size;
        }
        set {
            var isoObj = this.GetOrAddComponent<IsoObject>();
            isoObj.Size = value;
        }
    }

	public void setFCost(float hCost){
		fCost = gCost + hCost;
	}
	
	void Start() {
		obj = GetComponent<IsoObject>();
		edges = new HashSet<Tile> ();
	}
	
//	void OnDrawGizmos() {
//		Gizmos.color = Color.yellow;
//		Gizmos.DrawSphere(Isometric.isoProjection(obj.Position), .3f);
//	}
	
	bool equals(Tile n){
		return this.Position.Equals (n.Position);
	}

	void OnMouseUp() {
		//if(EventSystem.current.IsPointerOverGameObject())
			//return;
		var isoObj = this.GetOrAddComponent<IsoObject>();
		Debug.Log ("we clicked" + isoObj.Position.x + isoObj.Position.y + isoObj.Position.z);

		pathFinder.AStar ((int)Position.x, (int)Position.y, (int)Position.z);
	}
 
}
