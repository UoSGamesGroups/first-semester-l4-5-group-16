using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public GameObject door;

    private Pressed pressed;

    void Awake(){
        pressed = this.gameObject.GetComponent<Pressed>();
	}

    void Update()
    {
        if (pressed.pressed)
        {
            door.GetComponent<SpriteRenderer>().enabled = false;
            door.GetComponent<BoxCollider2D>().enabled = false;
           // door.GetComponent<AudioSource>().PlayOneShot(doorOpen);
        } else
        {
            door.GetComponent<SpriteRenderer>().enabled = true;
            door.GetComponent<BoxCollider2D>().enabled = true;
         //   door.GetComponent<AudioSource>().PlayOneShot(doorClose);
        }

        
    }

}
