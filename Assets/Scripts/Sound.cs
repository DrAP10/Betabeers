using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    public AudioClip ShootClip;
    public AudioClip AlarmClip;
    float next = 0;
    bool shot = true;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (next <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot((shot)?ShootClip:AlarmClip);
            shot = !shot;
            //AudioSource.PlayClipAtPoint(ShootSound, transform.position);
            next = 4f;
        }
        else
            next -= Time.deltaTime;
    }
}
