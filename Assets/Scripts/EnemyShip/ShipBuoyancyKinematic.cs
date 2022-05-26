using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBuoyancyKinematic : MonoBehaviour {
    private float acceleration = 1;
    private float verticalSpeed;

    // Start is called before the first frame update
    void Start()  {
        verticalSpeed = 0;        

        //Le damos un impulso inicial a la oscilación vertical
        transform.position -= transform.up * 1.5f;
    }

    // Update is called once per frame
    void Update() {        
        float verticalLevel = transform.position.y;

        verticalSpeed -= verticalLevel * acceleration * Time.deltaTime;
        transform.position += transform.up * verticalSpeed * Time.deltaTime;
    }
}
