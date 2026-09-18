using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;

    [SerializeField]

    private CharacterController characterController;

    [SerializeField]
    private float jmpVelocity = 8f;

    [SerializeField]
    private float gravity = -15f;

    private float verticalVelocity;

    public float VerticalVelocity => verticalVelocity;


    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            if (verticalVelocity < 0f)
            {
                verticalVelocity = .2f;

            }
            if (inputController.Jump)
            {
                verticalVelocity = jmpVelocity;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }
}
