using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<Magic> magics;
    private float smoothSpeed = 2;

    private void Start()
    {
        StartCoroutine(SpellCasting());
    }

    private void FixedUpdate()
    {
        Vector3 targetPostition = new Vector3( player.transform.position.x, 
            transform.position.y, 
            player.transform.position.z ) ;
        transform.LookAt( targetPostition ) ;
    }

    private IEnumerator SpellCasting()
    {
        while (gameObject)
        {
            Cast(magics[Random.Range(0, magics.Count)]);
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        }
    }
    
    private void Cast(Magic magic)
    {
        Instantiate(magic.GameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
