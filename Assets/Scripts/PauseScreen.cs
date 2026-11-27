using UnityEngine;
public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string soundName;
    public void Show()
    {
        SoundManager.instance.Play(soundName);
        Pause();
        animator.Play("Show");
    }
    public void Hide()
    {
        Resume();
        animator.Play("Hide");
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
}