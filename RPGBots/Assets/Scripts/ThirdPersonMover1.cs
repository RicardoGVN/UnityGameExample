using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMover1 : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 1000f;
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody _rigidbody;
    /*// Start is called before the first frame update
    void Start()
    {
        
    }*/
    private void Awake() => _rigidbody = GetComponent<Rigidbody>();
    
    // Update is called once per frame
    void Update()
    {
        var mouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseMovement * Time.deltaTime * _turnSpeed, 0);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var velocity = new Vector3(horizontal, 0, vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        _rigidbody.MovePosition(transform.position + offset);
        
    }
}
