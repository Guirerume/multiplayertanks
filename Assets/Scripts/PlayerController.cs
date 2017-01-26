using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerSetup))]
[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    PlayerHealth m_pHealth;
    PlayerSetup m_pSetup;
    PlayerShoot m_pShoot;
    PlayerMotor m_pMotor;

	void Start ()
    {
        m_pHealth = GetComponent<PlayerHealth>();
        m_pSetup = GetComponent<PlayerSetup>();
        m_pShoot = GetComponent<PlayerShoot>();
        m_pMotor = GetComponent<PlayerMotor>();
    }

    Vector3 GetInput()
    {
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizon, 0, vertical);
    }

    void FixedUpdate()
    {
        Vector3 inputDirection = GetInput();
        m_pMotor.MovePlayer(inputDirection);
    }

    void Update()
    {
        Vector3 inputDirection = GetInput();
        if (inputDirection.sqrMagnitude > 0.25f)
        {
            m_pMotor.RotateChassis(inputDirection);
        }
    }
}
