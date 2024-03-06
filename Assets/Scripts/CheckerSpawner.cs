using System.Collections.Generic;
using UnityEngine;

public class CheckerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _checkerPrefab;
    [SerializeField] private Transform _checkerContainerParent;
    [SerializeField] private CheckerContainer _checkerContainer;
    [SerializeField] private CheckerMovement _checkerMovement;

    private List<Transform> _tiles;

    private const int MAX_TILE_NUM = 24;

    private void Start()
    {
        _tiles = BoardInfo.Tiles;
        _checkerContainer = _checkerContainerParent.GetComponent<CheckerContainer>();
    }

    public void SetCheckers()
    {
        FillFirstPlayerTiles();
        FillSecondPlayerTiles();
        _checkerMovement.AddTileListener();
    }

    private void FillFirstPlayerTiles()
    {
        int startIndex = 0;
        int endIndex = MAX_TILE_NUM;
        SetCheckers(_checkerContainer.FirstPlayerCheckers, startIndex, endIndex);
    }

    private void FillSecondPlayerTiles()
    {
        int startIndex = _tiles.Count - MAX_TILE_NUM;
        int endIndex = _tiles.Count - 1;
        SetCheckers(_checkerContainer.SecondPlayerCheckers, startIndex, endIndex);
    }

    private void SetCheckers(List<Transform> playerCheckers, int startIndex, int endIndex)
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            var tileInfo = _tiles[i].GetComponent<TileInfo>();
            if (tileInfo.IsWhite)
                continue;

            Vector2 tilePos = tileInfo.Coordinates;
            Color color = playerCheckers == _checkerContainer.FirstPlayerCheckers ? Color.red : Color.blue;
            Transform checker = InstanceChecker(tilePos, color);
            playerCheckers.Add(checker);
            tileInfo.IsFull = true;
        }
    }

    private Transform InstanceChecker(Vector2 pos, Color color)
    {
        Transform checker = Instantiate(_checkerPrefab, pos, Quaternion.identity, _checkerContainerParent);
        checker.GetComponent<CheckerInfo>().Init(pos, color);
        return checker;
    }
}
