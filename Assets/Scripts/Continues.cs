using UnityEngine;
using TMPro;


public class Continues : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI continuesText;

    private int continuesCount;

    public bool HasContinues => continuesCount > 0;

    private void Awake()
    {
        continuesCount = PlayerPrefs.GetInt("ContinuesCount", 3);
        UpdateContinuesText();

    }
    private void UpdateContinuesText()
    {

        continuesText.text = "X" + continuesCount;
    }

    public void LoseContinue()
    {
        continuesCount--;
        PlayerPrefs.SetInt("ContinuesCount", continuesCount);
        UpdateContinuesText();
    }


}
