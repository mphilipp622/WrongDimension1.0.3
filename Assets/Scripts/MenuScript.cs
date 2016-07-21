using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	Transform keymapPanel;
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;
	Text[] textBoxes;

	bool waitingForKey;

	void Start ()
	{
		keymapPanel = transform.FindChild("keymapPanel");
		keymapPanel.gameObject.SetActive(false);
		waitingForKey = false;

		for(int i = 0; i < 5; i++)
		{
			if(keymapPanel.GetChild(i).name == "DownKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.down.ToString();
			else if(keymapPanel.GetChild(i).name == "UpKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.up.ToString();
			else if(keymapPanel.GetChild(i).name == "JumpKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.jump.ToString();
			else if(keymapPanel.GetChild(i).name == "SwordKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.stab.ToString();
			else if(keymapPanel.GetChild(i).name == "GunKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.shoot.ToString();
		}
	}

	void Update () 
	{

	}

	public void OpenKeymapPanel()
	{
		if(keymapPanel.gameObject.activeSelf == false)
			keymapPanel.gameObject.SetActive(true);
		else
			keymapPanel.gameObject.SetActive(false);
	}

	void OnGUI()
	{
//		if(waitingForKey)
		keyEvent = Event.current;

		if(keyEvent.isKey && waitingForKey)
		{
			newKey = keyEvent.keyCode;
			waitingForKey = false;
		}
	}

	public void StartAssignment(string keyName)
	{
		if(!waitingForKey)
			StartCoroutine(AssignKey(keyName));
	}

	public void SendText(Text text)
	{
		buttonText = text;
	}

	IEnumerator WaitForKey()
	{
		while(!keyEvent.isKey)
		{
			yield return null;
		}
		//newKey = keyEvent.keyCode;
	}

	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;

		yield return WaitForKey();

		switch(keyName)
		{
		case "up":
			GameManager.GM.up = newKey;
			buttonText.text = GameManager.GM.up.ToString();
			PlayerPrefs.SetString("upKey", GameManager.GM.up.ToString());
			break;
		case "down":
			GameManager.GM.down = newKey;
			buttonText.text = GameManager.GM.down.ToString();
			PlayerPrefs.SetString("downKey", GameManager.GM.down.ToString());
			break;
		case "jump":
			GameManager.GM.jump = newKey;
			buttonText.text = GameManager.GM.jump.ToString();
			PlayerPrefs.SetString("jumpKey", GameManager.GM.jump.ToString());
			break;
		case "sword":
			GameManager.GM.stab = newKey;
			buttonText.text = GameManager.GM.stab.ToString();
			PlayerPrefs.SetString("swordKey", GameManager.GM.stab.ToString());
			break;
		case "gun":
			GameManager.GM.shoot = newKey;
			buttonText.text = GameManager.GM.shoot.ToString();
			PlayerPrefs.SetString("gunKey", GameManager.GM.shoot.ToString());
			break;
//		default:
//			yield return null;
//			break;
		}

		yield return null;
	}
}
