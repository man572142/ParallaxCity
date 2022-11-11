using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    
    [SerializeField]
    private float _parallaxFactor = 0;

    private Transform _mainCamera = null;
    private Vector3 _camStartPos = Vector3.zero;
    void Start()
    {
        _mainCamera = Camera.main.transform;
        _camStartPos = _mainCamera.position;
    }

    void Update()
    {
        float distance = (_mainCamera.position - _camStartPos).x;

        transform.position = new Vector3(_camStartPos.x + distance * _parallaxFactor,transform.position.y,transform.position.z);

    }
}
