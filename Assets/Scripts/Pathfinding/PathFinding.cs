using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PathFinding : MonoBehaviour {
	
	public UnitMovement selectedUnit;
	public GridMap map;

	void Start() {

	}
	
	public float CostToEnterTile(Vector3 sourcePosition, Vector3 targetPosition) {
		
		Tile t = map[(int)targetPosition.x, (int)targetPosition.y, (int)targetPosition.z];
		
		if(UnitCanEnterTile((int)targetPosition.x, (int)targetPosition.y, (int)targetPosition.z) == false)
			return Mathf.Infinity;
		
		float cost = t.movementCost;
		
		if( sourcePosition.x!=targetPosition.x && sourcePosition.y!=targetPosition.y && sourcePosition.z!=targetPosition.z) {
			// We are moving diagonally!  Fudge the cost for tie-breaking
			// Purely a cosmetic thing!
			cost += 0.001f;
		}
		
		return cost;
		
	}

	public bool UnitCanEnterTile(int x, int y, int z) {
		
		// We could test the unit's walk/hover/fly type against various
		// terrain flags here to see if they are allowed to enter the tile.
		
		return map[x,y,z].canBeReached;
	}

	public float heuristic(Vector3 source, Vector3 target){
		int movementCost = 1;

		float h = movementCost * Mathf.Max (Mathf.Abs (source.x - target.x), 
		                             Mathf.Abs (source.y - target.y));
		return h;
	}

	public void AStar(int x, int y, int z) {
		map.GenerateGraph ();

		// Clear out our unit's old path.
		selectedUnit.currentPath = null;
		
		if (UnitCanEnterTile (x, y, z) == false) {
			// We probably clicked on a mountain or something, so just quit out.
			return;
		}
		
		Tile source = map[
		                    (int)selectedUnit.Position.x,
		                    (int)selectedUnit.Position.y,
		                    (int)selectedUnit.Position.z
		];

		Tile target = map[x, y, z];
		
		// List of nodes to be evaluated
		List<Tile> open = new List<Tile> ();
		open.Add (source);

		List<Tile> closed = new List<Tile> ();


		source.gCost = 0;
		source.setFCost(heuristic (source.Position, target.Position));

		while (open.Count != 0) {
			Tile current = minFCost(open);

			if(current.Equals(target)){
				selectedUnit.currentPath = constructPath(target);
				return;
			}

			open.Remove(current);
			closed.Add(current);

			foreach(Tile edge in getEdges(current)){
				if(!closed.Contains(edge)){
					float tempGCost = current.gCost + CostToEnterTile(current.Position, edge.Position);

					if(!open.Contains(edge)){
						open.Add(edge);
					} else if(tempGCost < edge.gCost){
						edge.gCost = tempGCost;
						edge.setFCost(heuristic(edge.Position, target.Position));
						edge.parentNode = current;
					}
				}
			}
		}
	}

	private HashSet<Tile> getEdges(Tile node){
		HashSet<Tile> edges = node.edges;

		foreach (Tile n in edges) {
			if(!n.Position.x.Equals(n.parentNode.Position.x) 
			   && !n.Position.y.Equals(n.parentNode.Position.y)){
				n.gCost = node.gCost + 0.001f;
			} else {
				n.gCost = node.gCost;
			}

			n.parentNode = node;
		}

		return edges;
	}

	private List<Tile> constructPath(Tile n){
		List<Tile> path = null;

		while(n.parentNode != null){
			n = n.parentNode;
			path.Add(n);
		}

		return path;
	}

	private Tile minFCost(List<Tile> nodes){
		float temp = 999999;
		Tile tempNode = null;

		foreach(Tile n in nodes) {
			if(n.fCost < temp){
				temp = n.fCost;
				tempNode = n;
			}
		}

		return tempNode;
	}

	
}