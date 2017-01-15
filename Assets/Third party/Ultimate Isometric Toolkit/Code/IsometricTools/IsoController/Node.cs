using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(IsoObject))]
[ExecuteInEditMode]
public class Node : MonoBehaviour {

    [SerializeField]
    private IsoObject obj;
	public HashSet<Node> edges;
	public Node parentNode;
	public float gCost, fCost, hCost;

	public Node(int x, int y, int z){
		obj.Position = new Vector3 (x,y,z);
	}

    public Vector3 Position {
        get { return obj.Position; }
        set { obj.Position = value; }
    }

	public void setFCost(float hCost){
		fCost = gCost + hCost;
	}

	void Start() {
        obj = GetComponent<IsoObject>();
    }
	
    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Isometric.isoProjection(obj.Position), .3f);
    }

	bool equals(Node n){
		return this.Position.Equals (n.Position);
	}
}
