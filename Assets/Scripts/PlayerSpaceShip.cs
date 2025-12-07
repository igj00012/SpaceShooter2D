using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpaceShip : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float acceleration = 300f;

    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float health = 10f;

    [Header("Actions")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;

    [SerializeField] HPManager hpmanager;

    private void Start()
    {
        if (hpmanager != null)
        {
            hpmanager.UpdateHP(health);
        }
    }

    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();

        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        shoot.action.started += OnShoot;
    }

    Vector2 currentVelocity = Vector2.zero;
    const float rawMoveTresholdorBreaking = 0.1f;
    // Update is called once per frame
    void Update()
    {
        if (rawMove.magnitude < rawMoveTresholdorBreaking)
        {
            currentVelocity *= 0.1f * Time.deltaTime; //variable el 0.1
        }

        currentVelocity += rawMove * acceleration * Time.deltaTime;

        float linearVelocity = currentVelocity.magnitude;
        linearVelocity = Mathf.Clamp(linearVelocity, 0, maxSpeed);
        currentVelocity = currentVelocity.normalized * linearVelocity;

        transform.Translate(currentVelocity * Time.deltaTime);

        Debug.Log("Health: " + health);
    }

    private void OnDisable()
    {
        move.action.Disable();
        shoot.action.Disable();

        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;

        shoot.action.started += OnShoot;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (hpmanager != null)
        {
            hpmanager.UpdateHP(health);
        }

        if (health <= 0) Destroy(gameObject);
    }

    Vector2 rawMove;
    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
