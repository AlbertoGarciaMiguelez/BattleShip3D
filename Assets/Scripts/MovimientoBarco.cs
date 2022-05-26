using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovimientoBarco : MonoBehaviour
{
    public float potenciaDelantera=0;
    public float velocidadGiro=0;
    public float nivelActual=0;
    public float nivelTimon=0;
    private float velocidadBaseGiro=1.2f;
    private float velocidadBaseMotor=0.8f;
    private float velocidadFriccionBase=0.2f;
    private float velocidadFinal;
    private float velocidadNudos;
    private string direccion="-";
    public TextMeshProUGUI potencia;
    public TextMeshProUGUI velocidad;
    public TextMeshProUGUI timon;
    public TextMeshProUGUI LR;
    Vector3 startPosition;
    private Vector3 playerVelocity = Vector3.zero;
    private CharacterController charController;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        charController = GetComponent<CharacterController>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = Vector3.zero;
        if(Input.GetKeyDown(KeyCode.W)){
            Debug.Log("Movimiento");
            if(nivelActual>=6){
                Debug.Log(nivelActual  + "Nivel Maximo");
            }else{
                nivelActual++;
                potenciaDelantera = nivelActual*velocidadBaseMotor;
                Debug.Log(potenciaDelantera);
                Debug.Log(nivelActual);
            }
        }
        else if(Input.GetKeyDown(KeyCode.S)){
            
            if(nivelActual<=0){
                Debug.Log(nivelActual + "Nivel Minimo");
            }else{
                nivelActual--;
                potenciaDelantera = nivelActual*velocidadBaseMotor;
                Debug.Log(potenciaDelantera);
                Debug.Log(nivelActual);
                if(nivelActual==0){
                    nivelTimon=0;
                    velocidadGiro=0;
                    potenciaDelantera=0;
                }
            }
        }
        else if(Input.GetKeyDown(KeyCode.A)){
            if(nivelTimon<=-3 || nivelActual==0){
                Debug.Log("Stop giro izquierda");
            }else{
                nivelTimon--;
                velocidadGiro= nivelTimon*velocidadBaseGiro;
                Debug.Log(velocidadGiro);
            }
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            if(nivelTimon>=3 || nivelActual==0){
                Debug.Log("Stop");
            }else{
                nivelTimon++;
                velocidadGiro= nivelTimon*velocidadBaseGiro;
                Debug.Log(velocidadGiro);
            }
        }
        if(nivelTimon<0){
            direccion="L";
        }else if(nivelTimon==0){
            direccion="-";
        }else if(nivelTimon>0){
            direccion="R";
        }
        velocidadFinal= potenciaDelantera-(Mathf.Abs(nivelTimon)*velocidadFriccionBase);
        Debug.Log(velocidadFinal);
        velocidadNudos = velocidadFinal*1.944f;
        velocidad.text = velocidadNudos.ToString();
        potencia.text = nivelActual.ToString();
        timon.text = Mathf.Abs(nivelTimon).ToString();
        LR.text = direccion;

        /*
        Vector3 newPosition = transform.position;
        newPosition += Vector3.right * velocidadFinal * Time.deltaTime;
        transform.position = newPosition;

        transform.position = new Vector3(transform.position.x + velocidadGiro, transform.position.y, transform.position.z + velocidadFinal); 
        */
        playerVelocity.x = movementInput.x * velocidadGiro;
        playerVelocity.z = movementInput.z * velocidadFinal;

        //transform.position = new Vector3(transform.position.x + velocidadGiro, transform.position.y, transform.position.z + velocidadFinal);
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y += velocidadGiro * Time.deltaTime;
        transform.eulerAngles = newRotation;
        velocity += transform.forward * velocidadFinal * Time.deltaTime;



        transform.position = transform.position + velocity * Time.deltaTime;
    }
}
