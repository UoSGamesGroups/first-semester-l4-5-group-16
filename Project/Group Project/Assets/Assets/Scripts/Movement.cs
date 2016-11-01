using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float movementSpeed = 2.5f;
	
	// Update is called once per frame
	void Update () {
	
	}

    public void move(int x, int y)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2((movementSpeed * x), (movementSpeed * y));
    }
}
