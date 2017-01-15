using UnityEngine;
using System.Collections;

public class Graph : MonoBehaviour {
//
//	public Tile[] graph;
//	
//	
//	public Vector3 mapSize;
//
//	public Tile getGraphNode(int x, int y, int z){
//		return graph[(int)(x * mapSize.y + y + z * mapSize.x * mapSize.y)];
//	}
//	
//	public Tile[] GenerateGraph() {
//		// Initialize the array
//		graph = new tile[(int)mapSize.x* (int)mapSize.y* ((int)mapSize.z + 1)];
//		
//		// Initialize a Node for each spot in the array
///*		for(int x=0; x < mapSize.x; x++) {
//			for(int y=0; y < mapSize.y; y++) {
//				for(int z=0; z <mapSize.z; z++){
//					graph[(int)(x * mapSize.y + y + z * mapSize.x * mapSize.y)] = new Node(x,y,z);
//				}
//			}
//		} */
//		
//		// Now that all the nodes exist, calculate their edges
//		for(int x=0; x < mapSize.x; x++) {
//			for(int y=0; y < mapSize.y; y++) {
//				for(int z=0; z < mapSize.z; z++){
//					
//					// This is the 8-way connection version (allows diagonal movement)
//					// Try left
//					if(x > 0) {
//						getGraphNode(x,y,z).edges.Add( getGraphNode(x-1, y, z) );
//						if(y > 0)
//							getGraphNode(x,y,z).edges.Add( getGraphNode(x-1, y-1, z) );
//						if(y < mapSize.y-1)
//							getGraphNode(x,y,z).edges.Add( getGraphNode(x-1, y+1, z) );
//					}
//					
//					// Try Right
//					if(x < mapSize.x-1) {
//						getGraphNode(x,y,z).edges.Add( getGraphNode(x+1, y, z) );
//						if(y > 0)
//							getGraphNode(x,y,z).edges.Add( getGraphNode(x+1, y-1, z) );
//						if(y < mapSize.y-1)
//							getGraphNode(x,y,z).edges.Add( getGraphNode(x+1, y+1, z) );
//					}
//					
//					// Try straight up and down
//					if(y > 0)
//						getGraphNode(x,y,z).edges.Add( getGraphNode(x, y-1, z) );
//					if(y < mapSize.y-1)
//						getGraphNode(x,y,z).edges.Add( getGraphNode(x, y+1, z) );
//					
//					// Try height up and down
//					/*if(z > 0){
//					getGraphNode(x,y,z).edges.Add( getGraphNode(x, y, z-1));
//				}
//				if( z < mapSize.z-1){
//					getGraphNode(x,y,z).edges.Add( getGraphNode(x, y, z+1) );
//				}*/
//					
//					// This also works with 6-way hexes and n-way variable areas (like EU4)
//					
//				}
//			}
//		}
//
//		return graph;
//	}
}
