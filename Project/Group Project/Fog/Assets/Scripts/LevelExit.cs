using UnityEngine;
using System.Collections;

public class LevelExit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(levelTransition(0.2f));
        }
    }

    IEnumerator levelTransition(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
