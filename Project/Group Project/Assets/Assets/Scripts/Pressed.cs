using UnityEngine;
using System.Collections;

public class Pressed : MonoBehaviour {

    public bool pressed;
	// Use this for initialization
	void Start () {
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D()
    {
        pressed = true;
    }

  //  void OnTriggerEnter2D(Collider2D coll)    {
  //      pressed = true;
 //   }

    void OnTriggerExit2D(Collider2D coll)
    {
        pressed = false;
    }
}
