using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    public Vector3 destination;
    private Vector3 previousPosition;
    private bool reachDestination;

    [SerializeField] private float stopDistance = 0.1f;
    [SerializeField] private float rotationSpeed = 720f;
    [SerializeField] private float movementSpeed = 2f;

    private static readonly int ForwardParam = Animator.StringToHash("Forward");
    private static readonly int HorizontalParam = Animator.StringToHash("Horizontal");

    void Start()
    {
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
        reachDestination = false;
        destination = transform.position; // Initialize destination
    }

    void Update()
    {
        MoveTowardsDestination();
        UpdateAnimatorParameters();
    }

    void MoveTowardsDestination()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float distance = destinationDirection.magnitude;

            if (distance > stopDistance)
            {
                reachDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                
                // Move towards destination
                transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
            }
            else
            {
                reachDestination = true;
            }
        }
    }

    void UpdateAnimatorParameters()
    {
        Vector3 movement = transform.position - previousPosition;
        previousPosition = transform.position;
        movement.y = 0;

        if (movement.magnitude > 0.01f)
        {
            Vector3 normalizedMovement = movement.normalized;
            float forwardMovement = Vector3.Dot(normalizedMovement, transform.forward);
            float rightMovement = Vector3.Dot(normalizedMovement, transform.right);

            animator.SetFloat(ForwardParam, forwardMovement);
            animator.SetFloat(HorizontalParam, rightMovement);
        }
        else
        {
            animator.SetFloat(ForwardParam, 0);
            animator.SetFloat(HorizontalParam, 0);
        }

        if (reachDestination)
        {
            // You can add any specific behavior here when destination is reached
            reachDestination = false;
        }
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
        reachDestination = false;
    }
}