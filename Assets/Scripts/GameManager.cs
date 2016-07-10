using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager GM;

	int _levelUnlocked;

	public int levelUnlocked
	{
		get
		{
			return _levelUnlocked;
		}
		set
		{
			_levelUnlocked = value;
		}
	}

	void Awake()
	{
		if(GM == null)
		{
			DontDestroyOnLoad(gameObject);
			GM = this;
		}	
		else if(GM != this)
		{
			Destroy(gameObject);
		}


	}

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerProgress.dat");

		PlayerData data = new PlayerData();
		data.levelUnlocked = _levelUnlocked;

		bf.Serialize(file, data);
		file.Close();
	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerProgress.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerProgress.dat", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();

			_levelUnlocked = data.levelUnlocked; // assign our highest level to the data in the file
		}
	}
}

[Serializable]
class PlayerData
{
	int _levelUnlocked;

	public int levelUnlocked
	{
		get
		{
			return _levelUnlocked;
		}
		set
		{
			_levelUnlocked = value;
		}
	}
}