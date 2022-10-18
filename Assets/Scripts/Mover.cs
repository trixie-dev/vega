using UnityEngine;

public class Mover : MonoBehaviour
{ 
    public CharacterController controller;
    [SerializeField] float gravity = -9.81f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;

    Vector3 velocity;

    public float rotationSpeed;

    protected virtual void Update() {
        
        // Gravity 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
    protected virtual void Move(Vector3 input, float speed)
    {   
        Vector3 direction = new Vector3(input.x, input.y, input.z).normalized;
        controller.Move(direction * speed * Time.deltaTime);
        Rotation(input);        
    }

    protected virtual void Rotation(Vector3 input)
    {
        float horizontal = input.x;
        float vertical = input.z;
        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            float angel = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.y, lookRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, angel, 0f);
        }
    }
}