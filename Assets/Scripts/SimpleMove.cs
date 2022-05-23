using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMove : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int speed;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // var move = context.ReadValue<Vector2>();
        // moveFinal = new Vector3(move.x, 0, move.y);
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        var mousePosition = context.ReadValue<Vector2>();
        Ray screenPointToRay = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(screenPointToRay, out RaycastHit raycastHit, float.MaxValue, layer))
        {
            Vector3 raycastHitPoint = raycastHit.point;
            transform.position = Vector3.MoveTowards(transform.position, raycastHitPoint, Time.deltaTime * speed);
            transform.LookAt(new Vector3(raycastHitPoint.x, transform.position.y, raycastHitPoint.z));
        }
    }


    private void FixedUpdate()
    {
       
    }
}