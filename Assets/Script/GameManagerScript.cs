using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour {

	[System.Serializable]  //Show inspector
	public class Grid{
		public int m_shapeNum;
		public int m_row;
		public int m_collumn;
		public int m_distance; //distance between grid
		public List<Vector3> gridPosition= new List<Vector3>();

		public Grid(int shapeNum,int row,int collumn,int distance){
			m_shapeNum = shapeNum;
			m_row = row;
			m_collumn = collumn;
			m_distance = distance;
		}
	}

	public List<GameObject> shapeList = new List<GameObject> ();
	public GameObject player;
	public GameObject[] prefabs;

	void Start () {
		SetUpScene ();
	}

	void Update(){
		foreach (GameObject shape in shapeList) {
			BasicShapeScript script = (BasicShapeScript)shape.GetComponent(typeof(BasicShapeScript));//get basic script
			script.Jump();
			if (script.IsPlayerNearBy(player)) {
				script.interactWithPlayer(player);
			}
		}
	}

	void CreateGrid(int row, int collumn, int distance, List<Vector3> grid){
		grid.Clear ();
		for (int x=0; x<row; x++) {
			for (int z=0; z<  collumn; z++) {
				grid.Add (new Vector3 (x * distance, 2f, z * distance)); // Create index
			}
		}
	}

	Vector3 GetRandomPosition (List<Vector3> grid){	//random index
		int index = Random.Range (0, grid.Count);
		Vector3 randomPosition = grid [index];
		grid.RemoveAt (index);
		return randomPosition;
	}
	
	void SetUpScene(){
		Grid grid = new Grid (20, 6, 5, 5);
		CreateGrid (grid.m_row, grid.m_collumn, grid.m_distance, grid.gridPosition);

		for (int z = 0; z < grid.m_shapeNum; z++) {
			Vector3 spawnPosition = GetRandomPosition(grid.gridPosition);
			GameObject randomPrefab = prefabs[Random.Range(0,prefabs.Length)];
			GameObject instance =  (GameObject)Instantiate(randomPrefab,spawnPosition,Quaternion.identity);
			shapeList.Add(instance);
		}
	}
	
}
