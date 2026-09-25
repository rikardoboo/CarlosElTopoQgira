using UnityEngine;
using UnityEngine.Events;

public class RollController : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    [SerializeField]

    private UnityEvent onRoll;
    [SerializeField]

    private float rollDuration = 1f;
    [SerializeField]
    private bool isRolling = false;
    [SerializeField]
    private GameObject rollEffectPrefab;
    [SerializeField]
    private float effectOffsetY = 0.5f;
    

    private void Update()
    {
        if (!isRolling && inputController.Roll)
        {
            Roll();

        }
    }
    private void Roll()
    {
        PoolManager.Instance.GetObject(rollEffectPrefab, transform.position + (Vector3.up * effectOffsetY));
        isRolling = true;
        onRoll?.Invoke();
        Invoke(nameof(EndRoll), rollDuration);

    }
    private void EndRoll()
    {
        isRolling = false;
    }

}
