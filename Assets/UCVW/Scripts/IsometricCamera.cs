using UnityEngine;
using System.Collections;

public class IsometricCamera : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
	   target = GameObject.Find("unitychan");
	}
	
    void LateUpdate()
    {
        transform.position = target.transform.position;
    }

	// Update is called once per frame
	void Update () {

	}
}
