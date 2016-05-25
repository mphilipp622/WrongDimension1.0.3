using UnityEngine;
using System.Collections;

public class ExplosionSmokeFadingScript : MonoBehaviour {

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;
    public SpriteRenderer sprite;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(Mathf.SmoothStep(minimum, maximum, t), Mathf.SmoothStep(minimum, maximum, t), Mathf.SmoothStep(minimum, maximum, t), Mathf.SmoothStep(minimum, maximum, t));
    }
}
