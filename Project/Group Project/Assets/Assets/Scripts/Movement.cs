using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Animator anim;
    public float movementSpeed = 2.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown (KeyCode.D))
            
                anim.SetInteger("State", 1);

        if (Input.GetKeyUp(KeyCode.D))

            anim.SetInteger("State", 0);

        if (Input.GetKeyDown(KeyCode.A))

            anim.SetInteger("State", 3);

        if (Input.GetKeyUp(KeyCode.A))

            anim.SetInteger("State", 0);

        if (Input.GetKeyDown(KeyCode.W))

            anim.SetInteger("State", 4);

        if (Input.GetKeyUp(KeyCode.W))

            anim.SetInteger("State", 0);
    }


    public void move(int x, int y)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2((movementSpeed * x), (movementSpeed * y));
       
    }
}
