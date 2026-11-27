using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InputController : MonoBehaviour
{
    [SerializeField]
    private bool debugMode = false;
    [SerializeField]
    private List<InputButton> inputButtons;
    public Vector2 Movement { get; private set; }
    private MoveDirection currentDirection;
    [SerializeField]
    private float movementThreshold = 0.1f;
    [SerializeField]
    private UnityEvent<MoveDirection> onMoveDirectionChanged;
    private bool isActive = true;
    public bool IsActive { set => isActive = value; }
    private void Update()
    {
        if (!isActive) return;
        UpdateMovement();
        foreach (var inputButton in inputButtons)
        {
            if (Input.GetKeyDown(inputButton.keyboardKey) || Input.GetKeyDown(inputButton.joystickKey))
            {
                inputButton.onPress.Invoke();
            }
        }
        if (debugMode)
        {
            DebugInput();
        }
    }
    private void DebugInput()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Key pressed: " + key);
            }
        }
    }
    private void UpdateMovement()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveDirection direction = GetMoveDirection(movement);
        if (direction != currentDirection)
        {
            currentDirection = direction;
            onMoveDirectionChanged.Invoke(direction);
        }
        Movement = movement;
    }
    private MoveDirection GetMoveDirection(Vector2 movement)
    {
        if (movement.magnitude < movementThreshold)
            return MoveDirection.None;
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            return movement.x > 0 ? MoveDirection.Right : MoveDirection.Left;
        else
            return movement.y > 0 ? MoveDirection.Up : MoveDirection.Down;
    }
}
[System.Serializable]
public class InputButton
{
    public string name;
    public KeyCode keyboardKey;
    public KeyCode joystickKey;
    public UnityEvent onPress;
}
public enum MoveDirection
{
    None,
    Up,
    Down,
    Left,
    Right
}