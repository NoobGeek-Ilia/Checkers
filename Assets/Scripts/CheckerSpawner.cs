using System.Collections.Generic;
using UnityEngine;

public class CheckerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _checkerPrefab;
    [SerializeField] private Transform _checkerContainerParent;
    [SerializeField] private CheckerContainer _checkerContainer;

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
            Transform checker = InstanceChecker(tilePos);
            playerCheckers.Add(checker);
            tileInfo.IsFull = true;
        }
    }

    private Transform InstanceChecker(Vector2 pos)
    {
        Transform checker = Instantiate(_checkerPrefab, pos, Quaternion.identity, _checkerContainerParent);
        checker.GetComponent<CheckerInfo>().Init(pos);
        return checker;
    }
}
