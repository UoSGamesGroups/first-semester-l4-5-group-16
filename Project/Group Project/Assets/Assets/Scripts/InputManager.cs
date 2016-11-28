using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    GameObject worldCamera;
    GameObject[] players;

    int currentPlayer;
    bool canSwap = true;

    // Use this for initialization
    void Start () {
        worldCamera = GameObject.Find("Main Camera");
        players = GameObject.FindGameObjectsWithTag("Player");
    }
	
	void Update () {
        checkInput();
	}
    
    //TODO: refactor out later with the coroutine, maybe
    void switchChar()
    {
        if (canSwap){
            players[currentPlayer].GetComponent<Movement>().move(0 , 0);
            players[currentPlayer].GetComponent<BoxCollider2D>().enabled = false;
            players[currentPlayer].GetComponent<CircleCollider2D>().enabled = false;
            if (currentPlayer + 1 < players.Length){
                currentPlayer++;
            }
            else {
                currentPlayer = 0;
            }

            worldCamera.GetComponent<CameraController>().ChangeFocus(players[currentPlayer]);
            players[currentPlayer].GetComponent<BoxCollider2D>().enabled = true;
            players[currentPlayer].GetComponent<CircleCollider2D>().enabled = true;
            canSwap = false;
            StartCoroutine(swapTimer(2.0f));
        }
    }

    IEnumerator swapTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canSwap = true;
    }

    void checkInput()
    {
        //char switching
        if (Input.GetButton("Switch")){
            switchChar();
        }

        //char interact
        if (Input.GetButton("Interact")){

        }

        //char movement
        int moveX = 0;
        int moveY = 0;
        int animation = 0;

        if (Input.GetButton("k_moveLeft") && !Input.GetButton("k_moveRight")) {
            moveX = -1;
            animation = 3;
        } else if (Input.GetButton("k_moveRight") && !Input.GetButton("k_moveLeft")) {
            moveX = 1;
            animation = 1;
        }

        if (Input.GetButton("k_moveUp") && !Input.GetButton("k_moveDown")){
            moveY = 1;
            animation = 4;
        }
        else if (Input.GetButton("k_moveDown") && !Input.GetButton("k_moveUp")){
            moveY = -1;
            animation = 0;
        }

        players[currentPlayer].GetComponent<Animator>().SetInteger("State", animation);
        players[currentPlayer].GetComponent<Movement>().move(moveX, moveY);
    }
}
