using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSave : MonoBehaviour {

    public Image level2;
    public bool level2Unlocked;
    public Image level3;
    public bool level3Unlocked;
    public Image level4;
    public bool level4Unlocked;
    public Image level5;
    public bool level5Unlocked;
    public Image level6;
    public bool level6Unlocked;
    public Image level7;
    public bool level7Unlocked;
    public Image level8;
    public bool level8Unlocked;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (level2Unlocked)
        {
            level2.color = new Color(1f, 1f, 1f, 1f);
        }
        if (!level2Unlocked)
        {
            level2.color = new Color(1f, 1f, 1f, 0.3f);
        }

        if (level3Unlocked)
            level3.color = new Color(1f, 1f, 1f, 1f);
        if (!level3Unlocked)
            level3.color = new Color(1f, 1f, 1f, 0.3f);

        if (level4Unlocked)
            level4.color = new Color(1f, 1f, 1f, 1f);
        if (!level4Unlocked)
            level4.color = new Color(1f, 1f, 1f, 0.3f);

        if (level5Unlocked)
            level5.color = new Color(1f, 1f, 1f, 1f);
        if (!level5Unlocked)
            level5.color = new Color(1f, 1f, 1f, 0.3f);

        if (level6Unlocked)
            level6.color = new Color(1f, 1f, 1f, 1f);
        if (!level6Unlocked)
            level6.color = new Color(1f, 1f, 1f, 0.3f);

        if (level7Unlocked)
            level7.color = new Color(1f, 1f, 1f, 1f);
        if (!level7Unlocked)
            level7.color = new Color(1f, 1f, 1f, 0.3f);

        if (level8Unlocked)
            level8.color = new Color(1f, 1f, 1f, 1f);
        if (!level8Unlocked)
            level8.color = new Color(1f, 1f, 1f, 0.3f);







    }
}
