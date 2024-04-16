using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Material _dirtyMaterial;
    [SerializeField] private Material _cleanMaterial;
    private Renderer _renderer;
    
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        CleaningZone.EndClean.AddListener(Change);
    }

    private void Change()
    {
        _renderer.material = _cleanMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
