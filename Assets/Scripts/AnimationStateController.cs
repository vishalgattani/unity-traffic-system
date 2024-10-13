using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    public Vector3 destination;
    private Vector3 previousPosition;
    public bool reachDestination;

    [SerializeField] private float stopDistance = 0.1f;
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private float movementSpeed = 2.0f;
    [SerializeField] private float collisionRotationAngle = 10f; // Angle to rotate on collision

    private static readonly int ForwardParam = Animator.StringToHash("Forward");
    private static readonly int HorizontalParam = Animator.StringToHash("Horizontal");
    private Rigidbody rb;
    void Awake(){  
        movementSpeed = Random.Range(1.75f, 2.25f);
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
        reachDestination = false;
        // destination = transform.position; // Initialize destination
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag)) // Check if colliding with same kind of object
        {
            float rotationDirection = Random.value < 0.5f ? -1f : 1f;
            //rotate around y axis
            transform.Rotate(0, collisionRotationAngle * rotationDirection, 0);
            // destination += transform.forward * 0.5f; // i if needed move destination slightly forward
        }
    }

    void UpdateAnimatorParameters()
    {
        Vector3 movement = transform.position - previousPosition;
        previousPosition = transform.position;
        movement.y = 0;

        var velocityMagnitude = movement.magnitude;

        Vector3 normalizedMovement = movement.normalized;
        float forwardMovement = Vector3.Dot(normalizedMovement, transform.forward);
        float rightMovement = Vector3.Dot(normalizedMovement, transform.right);

        animator.SetFloat(ForwardParam, forwardMovement);
        animator.SetFloat(HorizontalParam, rightMovement);

        if (reachDestination)
        {
            animator.SetFloat(ForwardParam, 0);
            animator.SetFloat(HorizontalParam, 0);
            // reachDestination = false;
        }
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
        reachDestination = false;
    }
}