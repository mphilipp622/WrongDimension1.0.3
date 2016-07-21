﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager GM;

	int _levelUnlocked;

	public KeyCode jump {get;set;}
	public KeyCode up {get;set;}
	public KeyCode down {get;set;}
	public KeyCode shoot {get; set;}
	public KeyCode stab {get; set;}

	public List<KeyCode> keycodes {get; set;}

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

		jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
		up = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
		down = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
		stab = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("swordKey", "R"));
		shoot = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("gunKey", "E"));

		keycodes = new List<KeyCode>();

		keycodes.Add(jump);
		keycodes.Add(up);
		keycodes.Add(down);
		keycodes.Add(stab);
		keycodes.Add(shoot);
//
//		jump = KeyCode.Space;
//		up = KeyCode.W;
//		down = KeyCode.S;
//		stab = KeyCode.R;
//		shoot = KeyCode.E;
	}

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}

	public void UpdateKeyList()
	{
		keycodes.Clear();

		keycodes.Add(jump);
		keycodes.Add(up);
		keycodes.Add(down);
		keycodes.Add(stab);
		keycodes.Add(shoot);

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