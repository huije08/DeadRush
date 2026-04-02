using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float forwardSpeed = 10f;
    [SerializeField] public float horizontalSpeed = 7f;

    
    [SerializeField] public float horizontalLimit = 5f;

    [SerializeField] public float tiltAmount = 10f;
    [SerializeField] public float tiltSmooth = 5f;

    private CharacterController controller;
    private float currentTilt = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 입력 받기
        float xInput = Input.GetAxis("Horizontal");

        // 이동 벡터
        float xMove = xInput * horizontalSpeed;
        float zMove = forwardSpeed;

        Vector3 move = new Vector3(xMove, 0, zMove);

        // 이동 적용
        controller.Move(move * Time.deltaTime);

        // 좌우 제한
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -horizontalLimit, horizontalLimit);
        transform.position = pos;

        // 기울기 (부드럽게)
        float targetTilt = -xInput * tiltAmount;
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSmooth);

        transform.rotation = Quaternion.Euler(0, 0, currentTilt);
    }
}