using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed = 90f;
    [SerializeField] private InputsBehaviour _inputsBehaviour;

    [Header("Components")]    
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    [Header("Debug")]
    public Vector3 CurInput;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 direction = _inputsBehaviour.Direction();
        Vector3 flatDirection = new Vector3(direction.x, 0f, direction.y).normalized;

        if (flatDirection != Vector3.zero)
        {            
            Quaternion targetRotation = Quaternion.LookRotation(flatDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
        if (_inputsBehaviour.Direction().magnitude > 0)
        {
            _characterController.Move(transform.forward * _speed * Time.deltaTime);
        }        
                
        SetRunAnimationActive(flatDirection.magnitude > 0);
    }
    /*void FixedUpdate()
    {
        CurInput = _inputsBehaviour.Direction().Flat();
        
        MovementUpdate();        
    }
    private void MovementUpdate()
    { 
        var flattedVector = _inputsBehaviour.Direction().Flat();

        SetRunAnimationActive(flattedVector.z != 0);

        
        transform.Rotate(Vector3.up, flattedVector.x * _rotationSpeed * Time.deltaTime);
        _characterController.Move(transform.forward * (flattedVector.z * _speed * Time.deltaTime));      
    }   */
    private void SetRunAnimationActive(bool isActive)
    {
        _animator.SetBool(IsWalking, isActive);
    }
}
