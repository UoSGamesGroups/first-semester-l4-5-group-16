using UnityEngine;
using System.Collections;

public class Pressed : MonoBehaviour {

    public bool pressed;


    public AudioClip doorOpen;
    public AudioClip doorClose;
    public GameObject door;

    // Use this for initialization
    void Start () {
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerStay2D()
    {
        if (!pressed)
        {
            door.GetComponent<AudioSource>().PlayOneShot(doorOpen);
        }
        pressed = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (pressed)
        {
            door.GetComponent<AudioSource>().PlayOneShot(doorClose);
        }
        pressed = false;
    }
}
