using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveForce = 10f;
    [SerializeField] float _fallSpeed = -10f;

    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalVelocity = new Vector3(Time.deltaTime * 3f * _moveForce * horizontalInput, 0, 0);

        float currentVerticalVelocity = Mathf.Max(_rb.linearVelocity.y, _fallSpeed);

        _rb.linearVelocity = horizontalVelocity + Vector3.up * currentVerticalVelocity;

        if (Input.GetMouseButton(0)) 
        {
            Vector3 mousePosition = Input.mousePosition;

            float direction = mousePosition.x < Screen.width / 2 ? -1f : 1f;

            // Устанавливаем горизонтальную скорость
            horizontalVelocity = new Vector3(Time.deltaTime * _moveForce * direction, 0, 0);

            currentVerticalVelocity = Mathf.Max(_rb.linearVelocity.y, _fallSpeed);

            _rb.linearVelocity = new Vector3(horizontalVelocity.x, currentVerticalVelocity, 0);
        }
    }
}
