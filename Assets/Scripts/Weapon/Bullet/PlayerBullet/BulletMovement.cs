using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private Rigidbody2D rigidbody;

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.right * speed;
    }
}
