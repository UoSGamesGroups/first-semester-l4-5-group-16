using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //Take control of other character
    int takovertime;
    public GameObject controlObject;

    //Input Control
    public KeyCode k_moveUp;
    public KeyCode k_moveRight;
    public KeyCode k_moveDown;
    public KeyCode k_moveLeft;

    public KeyCode k_swap;

    //Player Variable
    float movementSpeed = 2.5f;

    Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        controlObject = this.gameObject;

    }

    // Update is called once per frame
    void Update() {
        MovementController(controlObject);

    }

    void ChangeControlObject(GameObject obj)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
        controlObject = obj;
        rb = obj.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        if (obj != this.gameObject)

        {
            StartCoroutine(controlTimer(5));
        }

    }

    void MovementController(GameObject obj)
    {
        // Up - Left
        if (Input.GetKey(k_moveLeft) && Input.GetKey(k_moveUp))
        {
            rb.velocity = new Vector2(-movementSpeed, movementSpeed); // * Time.deltaTime;
        }
        //Up
        else if (Input.GetKey(k_moveUp) && !Input.GetKey(k_moveRight) && !Input.GetKey(k_moveLeft)) //if up and not right or left
        {
            rb.velocity = new Vector2(0, movementSpeed);
        }
        //Up-Right
        else if (Input.GetKey(k_moveUp) && Input.GetKey(k_moveRight))
        {
            rb.velocity = new Vector2(movementSpeed, movementSpeed);
        }
        //Right
        else if (Input.GetKey(k_moveRight) && !Input.GetKey(k_moveUp) && !Input.GetKey(k_moveDown)) //if right and not up or down
        {
            rb.velocity = new Vector2(movementSpeed, 0);
        }
        //Down-Right
        else if (Input.GetKey(k_moveDown) && Input.GetKey(k_moveRight))
        {
            rb.velocity = new Vector2(movementSpeed, -movementSpeed);
        }
        //Down
        else if (Input.GetKey(k_moveDown) && !Input.GetKey(k_moveRight) && !Input.GetKey(k_moveLeft)) //if down and not right or left
        {
            rb.velocity = new Vector2(0, -movementSpeed);
        }
        //Down-Left
        else if (Input.GetKey(k_moveDown) && Input.GetKey(k_moveLeft))
        {
            rb.velocity = new Vector2(-movementSpeed, -movementSpeed);
        }
        //Left
        else if (Input.GetKey(k_moveLeft) && !Input.GetKey(k_moveUp) && !Input.GetKey(k_moveDown)) //if left and not up or down
        {
            rb.velocity = new Vector2(-movementSpeed, 0);
        }
        else if (!Input.GetKey(k_moveUp) && !Input.GetKey(k_moveRight) && !Input.GetKey(k_moveDown) && !Input.GetKey(k_moveLeft))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerStay2D(Collider2D colObj)
    {
        if (Input.GetKey(k_swap))
        {
            ChangeControlObject(colObj.gameObject);
        }
    }

    IEnumerator controlTimer(int controlTime)
    {
        yield return new WaitForSeconds(controlTime);
        ChangeControlObject(this.gameObject);
    }

}
