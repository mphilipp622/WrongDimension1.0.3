using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using com.ootii.Input;

public class GameManager : MonoBehaviour {

	public static GameManager GM;

	int _levelUnlocked;

//	public KeyCode jump {get;set;}
//	public KeyCode up {get;set;}
//	public KeyCode down {get;set;}
//	public KeyCode shoot {get; set;}
//	public KeyCode stab {get; set;}
//
//	public List<KeyCode> keycodes {get; set;}

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

		LoadKeyMapping();

//		jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
//		up = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
//		down = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
//		stab = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("swordKey", "R"));
//		shoot = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("gunKey", "E"));
//
//		keycodes = new List<KeyCode>();
//
//		keycodes.Add(jump);
//		keycodes.Add(up);
//		keycodes.Add(down);
//		keycodes.Add(stab);
//		keycodes.Add(shoot);
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

//	public void UpdateKeyList()
//	{
//		keycodes.Clear();
//
//		keycodes.Add(jump);
//		keycodes.Add(up);
//		keycodes.Add(down);
//		keycodes.Add(stab);
//		keycodes.Add(shoot);
//
//	}

	void LoadKeyMapping()
	{
		InputManager.RemoveAliases();

		InputManager.AddAlias("ForwardKeyboard", PlayerPrefs.GetInt("ForwardKeyboard", EnumInput.W));
		InputManager.AddAlias("ForwardXbox", PlayerPrefs.GetInt("ForwardXbox", EnumInput.GAMEPAD_LEFT_STICK_Y));
		InputManager.AddAlias("BackKeyboard", PlayerPrefs.GetInt("BackKeyboard", EnumInput.S));
		InputManager.AddAlias("BackXbox", PlayerPrefs.GetInt("BackXbox", EnumInput.GAMEPAD_LEFT_STICK_Y));
		InputManager.AddAlias("JumpKeyboard", PlayerPrefs.GetInt("JumpKeyboard", EnumInput.SPACE));
		InputManager.AddAlias("JumpXbox", PlayerPrefs.GetInt("JumpXbox", EnumInput.GAMEPAD_0_BUTTON));
		InputManager.AddAlias("MeleeKeyboard", PlayerPrefs.GetInt("MeleeKeyboard", EnumInput.R));
		InputManager.AddAlias("MeleeXbox", PlayerPrefs.GetInt("MeleeXbox", EnumInput.GAMEPAD_2_BUTTON));
		InputManager.AddAlias("ShootKeyboard", PlayerPrefs.GetInt("ShootKeyboard", EnumInput.E));
		InputManager.AddAlias("ShootXbox", PlayerPrefs.GetInt("ShootXbox", EnumInput.GAMEPAD_1_BUTTON));
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