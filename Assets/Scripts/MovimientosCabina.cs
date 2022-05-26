using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosCabina : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 60f;
    private Vector3 playerVelocity = Vector3.zero;

    private CharacterController charController;

    // Start is called before the first frame update
    void Start() {
        charController = GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = Vector3.zero;
            movementInput.x = Input.GetAxis("Horizontal");
            
            
            movementInput = Camera.main.transform.TransformDirection(movementInput);

            movementInput = movementInput.normalized;


            playerVelocity.x = movementInput.x * speed;
            
            transform.forward = Vector3.Lerp(transform.forward,  movementInput, Time.deltaTime);
    }
    
}
