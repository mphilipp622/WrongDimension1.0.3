using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class example : MonoBehaviour {

	public void loadNextScene(){

		SceneManager.LoadScene("example_scene_2");

	}
}
