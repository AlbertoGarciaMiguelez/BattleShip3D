using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCanone : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 40f;
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
            movementInput.y = Input.GetAxis("Vertical");
            
            
            movementInput = Camera.main.transform.TransformDirection(movementInput);

            movementInput = movementInput.normalized;


            playerVelocity.y = movementInput.y * speed;
            
            transform.forward = Vector3.Lerp(transform.forward,  movementInput, Time.deltaTime);
    }
}
