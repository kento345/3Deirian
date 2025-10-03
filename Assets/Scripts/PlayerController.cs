using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    //-----ˆÚ“®-----
    [SerializeField] private float speed = 10;
    [SerializeField] private float magnitude;
    private Vector2 inputVer;
    //-----ŒŠ–x-----
    [SerializeField] private GameObject HolePrefab;
    [SerializeField] private Transform HolePos;


     
    [SerializeField] private Animator animator;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVer = context.ReadValue<Vector2>();
    }
    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(HolePrefab, HolePos);
        }
    }

    void Update()
    {
        Move();

        
    }

    void Move()
    {
       magnitude = inputVer.magnitude;
        

        Vector3 move = new Vector3(inputVer.x,0,inputVer.y) * speed * Time.deltaTime;
        transform.position += move;

        if (move != Vector3.zero)
        {
            Quaternion Rot = Quaternion.LookRotation(move,Vector3.up);
            transform.rotation = Rot;   
        }

        animator.SetFloat("Speed", magnitude);
    }
}
