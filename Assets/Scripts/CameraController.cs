using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform towerGun;

    private Vector3 offset = new Vector3(0, 2f, -2f);
    // Start is called before the first frame update
    void Start() {
        transform.position = towerGun.position + towerGun.TransformDirection(offset);
        transform.rotation = towerGun.rotation;
    }

    // Update is called once per frame
    void Update() {
        transform.position = towerGun.position + towerGun.TransformDirection(offset);
        transform.rotation = towerGun.rotation;
    }
}
