using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Runtime.CompilerServices;
public class SceneController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onSceneStarted;
    [SerializeField]
    private Animator fade;
    [SerializeField]
    private string fadeoutAnimationName = "FadeOut";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onSceneStarted?.Invoke();


    }

   public void GoToSceneWithFade(string  sceneName)
    {
        StartCoroutine(LoadSceneWithFade (sceneName));
    }
    private IEnumerator LoadSceneWithFade (string sceneName)
    {
        fade.Play(fadeoutAnimationName, 0, 0f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
