using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    Vector3 lastPos;

	// Use this for initialization
	void Start () {
        lastPos = target.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = target.position;
        if (newPos != lastPos)
        {
            Vector3 diff = newPos - lastPos;
            transform.position += diff;
            lastPos = newPos;
        }
	}
}
