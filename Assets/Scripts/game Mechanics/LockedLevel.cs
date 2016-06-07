using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockedLevel : MonoBehaviour
{

    [SerializeField]
    int levelNumber;

    [SerializeField]
    [Range(0, 1)]
    float alphaValue = .2f; // Alpha value of the locked levels. Default is .2

    Image thisImage;
    public bool canPlay;

    void Start()
    {
        thisImage = GetComponent<Image>();
        thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, alphaValue);
    }

    void Update()
    {
		#if UNITY_WEBGL
	        if (levelNumber <= PlayerPrefs.GetInt("HighestLevelUnlocked"))
	        {
	            thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 1);
	            canPlay = true;
	        }

		#else
			if (levelNumber <= GameManager.GM.levelUnlocked)
			{
				thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 1);
				canPlay = true;
			}

		#endif

    }



    public void loadLevel()
    {
        if (canPlay)
        {
            Application.LoadLevel(levelNumber);
        }

    }
}