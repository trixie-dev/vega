using UnityEngine;
using System.Linq;

public class Player : Mover
{

    [SerializeField] private float moveSpeed;

    //public Collider[] targets;


    private float horizontal;
    private float vertical;
    //private bool isFocusedOnTarget;
    //private bool isAttacking;
    //private bool isRunning;
    //private float attackDuration = 3.43f;



    public void Start()
    {
        
    }
    private void FixedUpdate()
    {
        // Input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(!isGrounded){
            horizontal/=2;
            vertical/=2;
        }
        // Move
        Move(new Vector3(horizontal, 0, vertical), moveSpeed);
              
    }

}