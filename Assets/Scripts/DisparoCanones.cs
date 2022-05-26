using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoCanones : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform shotPoint;
    private float shotForce = 600f;
    private bool coldown;
    public GameObject colorVerde;
    public GameObject colorRojo;
    // Start is called before the first frame update
    void Start()
    {
        coldown=true;
        colorRojo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && coldown == true){
            Shot();
            coldown=false;
            colorVerde.SetActive(false);
            colorRojo.SetActive(true);
            Invoke("Recargar", 4f);
        }
    }
    public void Shot(){
        GameObject bala = Instantiate(balaPrefab, shotPoint.position, shotPoint.rotation);
        bala.GetComponent<Rigidbody>().AddForce(bala.transform.forward * shotForce, ForceMode.Impulse);
        GetComponentInChildren<ParticleSystem>().Play();
    }
    public void Recargar(){
        Debug.Log("Recargado");
        coldown=true;
        colorVerde.SetActive(true);
        colorRojo.SetActive(false);
    }
}
