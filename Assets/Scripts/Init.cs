using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] private BoardBuilder _boardBuilder;
    [SerializeField] private CheckerSpawner _checkerSpawner;
    private void Start()
    {
        _boardBuilder.CreateBoard(BoardInfo.WIDTH, BoardInfo.HEIGHT);
        _checkerSpawner.SetCheckers();
    }
}