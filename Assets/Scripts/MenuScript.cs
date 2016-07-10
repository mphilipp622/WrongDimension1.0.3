using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	Transform menuPanel;

	void Start ()
	{
		menuPanel = transform.FindChild("MenuPanel");
		menuPanel.gameObject.SetActive(false);
	}

	void Update () 
	{
	
	}

	public void OpenPanel()
	{
		
	}
}
