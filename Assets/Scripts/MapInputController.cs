using UnityEngine;
using UnityEngine.Events;
public class MapInputController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<MapDirection> onInputChange;
    [SerializeField]
    private UnityEvent onSelectLevel;
    private bool isActive = true;
    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }
    private void Update()
    {
        if (!isActive) return;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            onInputChange.Invoke(MapDirection.Up);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            onInputChange.Invoke(MapDirection.Down);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            onInputChange.Invoke(MapDirection.Left);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            onInputChange.Invoke(MapDirection.Right);
        if (Input.GetKeyDown(KeyCode.Space))
            onSelectLevel.Invoke();
    }
}