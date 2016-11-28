using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public GameObject door;

	private SpriteRenderer dSpriteRenderer;
	private BoxCollider2D dBoxCollider;
    private Pressed pressed;

	void Awake(){


        dSpriteRenderer = door.GetComponent<SpriteRenderer>();
        dBoxCollider = door.GetComponent<BoxCollider2D>();
        pressed = this.gameObject.GetComponent<Pressed>();
	}

    void Update()
    {
        if (pressed.pressed)
        {
            dSpriteRenderer.enabled = false;
            dBoxCollider.enabled = false;
        } else
        {
            dSpriteRenderer.enabled = true;
            dBoxCollider.enabled = true;
        }

        
    }

}
