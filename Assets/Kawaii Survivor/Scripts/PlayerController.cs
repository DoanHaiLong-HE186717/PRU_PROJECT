using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Elements")]     
    [SerializeField]
    private MobileJoystick playerJoystick;

    [Header("Settings")]
    [SerializeField]
    private Rigidbody2D rig;
    [SerializeField]
    private float moveSpeed;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        rig.linearVelocity = playerJoystick.GetMoveVector() * moveSpeed * Time.deltaTime;
    }
}
