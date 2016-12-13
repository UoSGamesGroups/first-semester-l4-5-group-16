using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Image cooldown;
    public bool levelTime;
    public float waitTime = 30.0f;

    // Update is called once per frame
    void Update()
    {
        if (levelTime == true)
        {
            //Reduce fill amount over 30 seconds
            cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;

            if (cooldown.fillAmount == 0f)
            {
                Debug.Log("Game Over");
            }
        }
    }
}