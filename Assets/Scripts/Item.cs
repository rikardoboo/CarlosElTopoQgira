using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]

    private GameObject itemParticle;
    [SerializeField]

    private string itemSoundName;

    public void Collect()
    {
        PoolManager.Instance.GetObject(itemParticle, transform.position);
        SoundManager.instance.Play(itemSoundName);
        gameObject.SetActive(false);
    }
}
