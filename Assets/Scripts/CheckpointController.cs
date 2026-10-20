using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform player;
    private Transform currentCheckPoint;
    public Transform CurrentCheckPoint { set { currentCheckPoint = value; } }

    private void Awake()
    {
        currentCheckPoint = startPoint;

    }
    public void MovePlayerToCheckpoint()
    {
        player.position = currentCheckPoint.position;
    }
}
