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
    
    //TODO: refactor out later, maybe
    void switchChar()
    {
        if (canSwap){
            if (currentPlayer + 1 < players.Length){
                currentPlayer++;
            }
            else {
                currentPlayer = 0;
            }

            worldCamera.GetComponent<CameraController>().ChangeFocus(players[currentPlayer]);

            canSwap = false;
            StartCoroutine(swapTimer(2.0f));
        }
    }

    IEnumerator swapTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canSwap = true;
        print("Swap Ready");
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

        if (Input.GetButton("k_moveLeft") && !Input.GetButton("k_moveRight")) {
            moveX = -1;
        } else if (Input.GetButton("k_moveRight") && !Input.GetButton("k_moveLeft")) {
            moveX = 1;
        }

        if (Input.GetButton("k_moveUp") && !Input.GetButton("k_moveDown")){
            moveY = 1;
        }
        else if (Input.GetButton("k_moveDown") && !Input.GetButton("k_moveUp")){
            moveY = -1;
        }

        players[currentPlayer].GetComponent<Movement>().move(moveX, moveY);
    }
}
