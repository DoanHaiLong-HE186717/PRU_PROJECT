using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerStatsDependency
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Elements")]     
    [SerializeField]
    private MobileJoystick playerJoystick;
    [SerializeField]
    private Rigidbody2D rig;

    [Header("Settings")]
    [SerializeField] 
    private float baseMoveSpeed;
    private float moveSpeed;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        rig.linearVelocity = playerJoystick.GetMoveVector() * moveSpeed * Time.deltaTime;
    }

    public void UpdateStats(PlayerStatsManager playerStatsManager)
    {
        float moveSpeedPercent = playerStatsManager.GetStatValue(Stat.MoveSpeed) / 100;
        moveSpeed = baseMoveSpeed * (1 + moveSpeedPercent);
    }
}
