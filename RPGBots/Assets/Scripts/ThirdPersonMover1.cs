using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMover1 : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 1000f;
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody _rigidbody;
    Animator _animator;

    /*// Start is called before the first frame update
        void Start()
    {
       
    }
   */
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        var mouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseMovement * Time.deltaTime * _turnSpeed, 0);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");//aquí da 1 o -1
        if (Input.GetKey(KeyCode.LeftShift))
            vertical *= 2f;
        var velocity = new Vector3(horizontal, 0, vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        _rigidbody.MovePosition(transform.position + offset);

        _animator.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);//entonces aquí va a cambiar el valor menor o mayor al que habíamos configurado
        _animator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
    }
}
