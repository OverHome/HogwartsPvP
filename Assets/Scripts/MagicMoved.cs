using System;
using System.Collections;
using UnityEngine;


public class MagicMoved : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Delete), 5);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, 1)*Time.deltaTime);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
