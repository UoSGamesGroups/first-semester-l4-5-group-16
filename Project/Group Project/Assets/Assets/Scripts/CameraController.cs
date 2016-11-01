using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private GameObject pc;

	// Use this for initialization
	void Start ()
    {
        ChangeFocus(GameObject.Find("Char1"));
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = new Vector3(pc.transform.position.x, pc.transform.position.y, -10);
        CameraControl(pc);
    }

    void CameraControl(GameObject obj)
    {
        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -10);
    }

    public void ChangeFocus(GameObject newTarget)
    {
        pc = newTarget;
    }
}
