using UnityEngine;
using UnityEngine.Events;
using System.Collections;
public class Lives : MonoBehaviour
{
    [SerializeField]
    private int startingLives;
    [SerializeField]
    private UnityEvent<float> onLoseLife;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent<float> startInvincibility;
    [SerializeField]
    private float invincibilityDuration = 2f;
    [SerializeField]
    private float fullInvincibilityDuration;
    private int invincibilityLimit = 1;
    private bool isInvincible;
    private bool isDead;
    public bool IsInvincible { get => isInvincible; set => isInvincible = value; }
    private int currentLives;
    public void Initialize()
    {
        currentLives = startingLives;
        isInvincible = false;
        isDead = false;
    }
    public void AddLife(int amount)
    {
        if (currentLives <= invincibilityLimit)
        {
            StartCoroutine(FullInvincibilityCoroutine());
        }
        else
        {
            currentLives += amount;
        }
    }
    public void LoseLife()
    {
        if (isInvincible || isDead) return;
        currentLives--;
        if (currentLives <= 0)
        {
           
            isDead = true;
            onDeath?.Invoke();
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }
    private IEnumerator InvincibilityCoroutine()
    {
        isDead = true;
        onLoseLife?.Invoke(invincibilityDuration);
        yield return new WaitForSeconds(invincibilityDuration);
        isDead = false;
    }
    private IEnumerator FullInvincibilityCoroutine()
    {
        isInvincible = true;
        startInvincibility?.Invoke(fullInvincibilityDuration);
        yield return new WaitForSeconds(fullInvincibilityDuration);
        isInvincible = false;
        // redinvisibility?.Invoke();
    }
    public void Kill()
    {
        isDead = true;
        currentLives = 0;
        onDeath?.Invoke();
    }
}


