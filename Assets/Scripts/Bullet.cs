using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public delegate void ReachedPointDelegate(Vector3 reachedPointCoordinates);
    public event ReachedPointDelegate reachedPoint;

    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter(Collision other){
        GameObject newEffect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(newEffect, newEffect.GetComponent<ParticleSystem>().main.duration);
        if(reachedPoint != null) {
            reachedPoint(transform.position);
        }
        Destroy(gameObject);        
    }
}
