using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorManager : MonoBehaviour {

	public static DoorManager doorManager;

	[SerializeField]
	GameObject[] doors;

	//[SerializeField]
	//List<Tiles> keys;

	GameObject[] tileObj;
	Tiles[] tiles;

	void Awake()
	{
		if(doorManager == null)
			doorManager = this;
		else if(doorManager != null)
			Destroy(gameObject);
	}

	void Start () 
	{
		doors = GameObject.FindGameObjectsWithTag("Door"); //Grab every Door in the scene and store it in array
		tileObj = GameObject.FindGameObjectsWithTag("Tile"); //Grab every tile in the scene and store it in array
		tiles = new Tiles[tileObj.Length]; //Create new array with number of indexes = to number of tiles in scene
		for(int i = 0; i < tileObj.Length; i++)
			tiles[i] = new Tiles(tileObj[i], false); //Assign each array index to be a new Tiles object

		System.Array.Clear(tileObj, 0, tileObj.Length); // Clear tileObj since we no longer need it.

		//keys = new List<Tiles>();
		//for(int i = 0; i < doors.Length; i++)
		//{
		//	for(int j = 0 ; j < doors[i].transform.childCount; j++)
		//		keys.Add(new Tiles(doors[i].transform.GetChild(j).gameObject, false));
		//}
	}
	

	void Update () 
	{
	
	}

	public void SetLit(GameObject key, bool lit)
	{
		//Function used for setting lit to true/false for the tile that's passed to it
		for(int i = 0; i < tiles.Length; i++)
		{
			//Search the array for the tile we passed to function
			if(tiles[i].GetObject() == key)
			{
				//if we find a match, set the lit status of the tile to true/false
				tiles[i].SetLit(lit);
				break; //Stop execution
			}
		}
		//if(keys.Contains(key))
		/*foreach(Tiles tile in keys)
		{
			if(tile.GetObject() == key)
			{
				tile.SetLit(lit);
				break;
			}
		}*/
	}

	public bool GetLit(GameObject key)
	{
		/*foreach(Tiles tile in keys)
		{
			if(tile.GetObject() == key)
			{
				return tile.IsLit();
			}
		}*/
		for(int i = 0; i < tiles.Length; i++)
		{
			if(tiles[i].GetObject() == key)
				return tiles[i].IsLit();
		}

		return false;
	}
}

class Tiles
{
	GameObject tile;
	bool lit;

	public Tiles(GameObject obj, bool isLit)
	{
		tile = obj;
		lit = isLit;
	}

	public void SetLit(bool isLit)
	{
		lit = isLit;
	}
	public bool IsLit()
	{
		return lit;
	}

	public GameObject GetObject()
	{
		return tile;
	}
		
}
