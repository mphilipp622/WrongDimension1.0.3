using UnityEngine;
using System.Collections;

public class MusicHanlder : MonoBehaviour {

     public AudioSource audioSource;
    public AudioClip genClip;
    public AudioClip underClip;
    
    private int currentLevel;

    int volUp = 1;
    int volDown = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = genClip;
        audioSource.Play();

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


    void OnLevelWasLoaded(int level)
    {
        if (level == 6)
        {
            FadeToUnder();
        }

        if (level != 6)
        {
            if(audioSource.clip == underClip)
            {
                audioSource.clip = genClip;
                audioSource.Play();

            }

        }
    }

    void FadeIn()
    {


    }

    void FadeToUnder()
    {
        //if (!audioSource.isPlaying)
        //{
            if (audioSource.clip != underClip)
            {
                //audioSource.volume = Mathf.Lerp(audioSource.volume, 0, Time.deltaTime);
                audioSource.clip = underClip;
                Debug.Log("UNDERGROUND");
            audioSource.Play();
            }

        //}

    }
}
