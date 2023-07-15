using UnityEngine;
using Zenject;

public class EnemyRotation : MonoBehaviour
{
    private Transform playerPosition;

    public bool IsFasingRight { get => isFasingRight; }
    private bool isFasingRight;

    [Inject]
    private void Init(PlayerHealth player)
    {
        playerPosition = player.transform;
    }

    private void Start()
    {
        isFasingRight = true;

        if (playerPosition.position.x < transform.position.x)
            Turn();
    }

    private void FixedUpdate()
    {
        if (transform.position.x < playerPosition.position.x && !IsFasingRight)
            Turn();
        else if (transform.position.x > playerPosition.position.x && IsFasingRight)
            Turn();
    }

    public void Turn()
    {
        isFasingRight = !isFasingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}