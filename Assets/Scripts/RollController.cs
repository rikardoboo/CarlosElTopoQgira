using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class RollController : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    [SerializeField]

    private UnityEvent onRoll;
    [SerializeField]

    
    private float cooldown = 0.5f;
    [SerializeField]
    private Collider rollCollider;
    [SerializeField]
    private float rollDuration = 1f;
    [SerializeField]
    private bool isRolling = false;
    [SerializeField]
 

    private GameObject rollEffectPrefab;

    public bool IsRolling => isRolling;
    private bool canRoll = true;
    [SerializeField]
    private float effectOffsetY = 0.5f;

    private void Awake()
    {
        rollCollider.enabled = false;
        canRoll = true;
    }
    private void Update()
    {
        if (canRoll &&!isRolling && inputController.Roll)
        {
            Roll();

        }
    }
    private void Roll()
    {
        rollCollider.enabled = true;
        canRoll = false;
        Transform rollparticles = PoolManager.Instance.GetObject(rollEffectPrefab, transform).transform;
        rollparticles.localPosition += new Vector3(0f, effectOffsetY, 0f);
        isRolling = true;
        onRoll?.Invoke();
        StartCoroutine(RollCoroutine());

    }
    private IEnumerator RollCoroutine()
    {
        yield return new WaitForSeconds(rollDuration);
        isRolling = false;
        rollCollider.enabled = false;
        yield return new WaitForSeconds(cooldown);
        canRoll = true;

    }

}
