using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Animator anim;
    public float movementSpeed = 2.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void move(int x, int y)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2((movementSpeed * x), (movementSpeed * y));
       
    }
}
