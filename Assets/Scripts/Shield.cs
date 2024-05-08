using System;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{
    [SerializeField] private List<Material> materials;

    public bool IsOn { get; private set; }
    private Renderer _renderer;
    private CapsuleCollider _capsuleCollider;
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _renderer.enabled = false;
        _capsuleCollider.enabled = false;
    }

    public void ShieldOn(int id)
    {
        _renderer.material = materials[id];
        _renderer.enabled = true;
        _capsuleCollider.enabled = true;
        IsOn = true;
    }
    
    public void ShieldOff()
    {
        _renderer.enabled = false;
        _capsuleCollider.enabled = false;
        IsOn = false;
    }
}
