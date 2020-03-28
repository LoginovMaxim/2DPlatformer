using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smooth;
    [SerializeField] private float _offset;
    
    void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, _target.position, _smooth * Time.deltaTime);
        transform.position += new Vector3(0, 0, _offset);
    }
}
