using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private bool canMove;
	private Vector3 targetPosition;
    private bool isFasingRight = true;

    [SerializeField] float speed;

    private Vector2 screenBounds;
    [SerializeField] private float offset;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void Update()
	{

		if (Input.GetMouseButton(0))
		{
			SetTargetPosition();
		}
	}

	private void FixedUpdate()
	{
        if (canMove)
        {
            Move();
        }
    }

	private void SetTargetPosition()
	{
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = transform.position.z;

		canMove = true;
	}

	private void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
        CheckBoundaries();

		if (transform.position.x > 0 && isFasingRight)
			Turn();
		else if (transform.position.x < 0 && !isFasingRight)
			Turn();
			
		if (transform.position == targetPosition)
		{
			canMove = false;
		}
	}

    private void Turn()
    {
        isFasingRight = !isFasingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void CheckBoundaries()
    {

        if (transform.position.x < -screenBounds.x + offset)
        {
            transform.position = new Vector2(-screenBounds.x + offset, transform.position.y);
        }
        else if (transform.position.x > screenBounds.x - offset)
        {
            transform.position = new Vector2(screenBounds.x - offset, transform.position.y);
        }

        if (transform.position.y < -screenBounds.y + offset)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y + offset);
        }
        else if (transform.position.y > screenBounds.y - offset)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y - offset);
        }
    }
}