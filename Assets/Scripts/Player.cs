using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float _velocity = 10;
    [SerializeField] private Animator _animator;
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 cameraRight = Camera.main.transform.right;
        Vector3 cameraForward = Quaternion.Euler(Vector3.up * -90) * cameraRight;
        Vector3 moveAxis = cameraRight * horizontal + cameraForward * vertical;

        if (moveAxis.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(moveAxis);
        }

        _characterController.SimpleMove(moveAxis.normalized * _velocity);

        _animator.SetBool("IsMoving", moveAxis.magnitude > 0);
    }
}
