using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    public float speedOffset;

    private void OnEnable()
    {
        Invoke("Destroy", 10f);
    }

    private void Start()
    {
        moveSpeed = speedOffset;
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
