using UnityEngine;
using System.Collections;

public class SpriteController : MonoBehaviour {

    private Animator animator;
    private GameObject player;
    public Vector3 rotation;
    private float angle;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rotation = Vector3.forward;
        angle = 0;
	}

    public void LookAt(Vector3 location) {
        // Sprite can only rotate in y direction
        rotation = location;
    }

    private void UpdateRotation() {
        if (rotation.x >= 0.0f) {
            angle = Vector3.Angle(Vector3.forward, rotation);
        } else {
            angle = 360 - Vector3.Angle(Vector3.forward, rotation);
        }

        float rotationAngle = (((transform.eulerAngles.y/4) - angle + 180) % 360);
        if (rotationAngle < 0) {
            rotationAngle = 360 + rotationAngle;
        }

        animator.SetFloat("Blend", 1 - (rotationAngle / 360));


        transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }



	// Update is called once per frame
	void Update () {
        this.UpdateRotation();
	}
}
