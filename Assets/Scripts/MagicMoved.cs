using System;
using System.Collections;
using UnityEngine;


public class MagicMoved : MonoBehaviour
{
    private Rigidbody _rb;
    private void Start()
    {
        Invoke(nameof(Delete), 10);
        _rb = GetComponent<Rigidbody>();
        var dir =  60 * transform.forward;
        _rb.AddForce(dir);
    }

    private void Update()
    {
        
        // transform.Translate(new Vector3(0, -5, 0)*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        var health = other.GetComponent<Health>();
        if (health == null) return;
        health.TakeDamege();
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
