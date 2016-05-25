using UnityEngine;
using System.Collections;

public class MusicHanlder : MonoBehaviour {

     public AudioSource audioSource;
    public AudioClip startingClip;
    public AudioClip playingClip;
    public AudioClip SecondplayingClip;
    private int currentLevel;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        /*audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = startingClip;
        audioSource.Play();
        audioSource.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
	
        

	}

    void OnLevelWasLoaded(int level)
    {
        if (level != 1 || level != currentLevel)
        {
            audioSource.clip = playingClip;
            audioSource.Play();
            audioSource.loop = true;
        }
        currentLevel = level;
    }

    public void ChangeSongs()
    {
    */

    }
}
