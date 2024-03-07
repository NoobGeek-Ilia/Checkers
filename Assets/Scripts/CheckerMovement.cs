using System.Collections.Generic;
using UnityEngine;

public class CheckerMovement : MonoBehaviour
{
    [SerializeField] private CheckerContainer _checkerContainer;
    [SerializeField] private InputHandler _inputHandler;

    private TileInfo _previousTileInfo;
    private CheckerInfo _previousCheckerInfo;

    private Transform _selectedChecker;
    private List<Transform> _roleTurnCheckers;

    public void AddTileListener()
    {
        _inputHandler.OnSelectedTile += CheckSelectedTile;
        _roleTurnCheckers = _checkerContainer.SecondPlayerCheckers;
    }

    private void CheckSelectedTile(Transform tile)
    {
        var tileInfo = tile.GetComponent<TileInfo>();
        if (tileInfo.IsFull)
        {
            _selectedChecker = GetSelectedChecker(tileInfo);
            return;
        }

        if (_selectedChecker == null)
            return;

        var conditionsIsMet = ConditionsIsMet(_previousTileInfo.Coordinates, tileInfo.Coordinates);
        if (conditionsIsMet)
        {
            SetNewCheckerCoordinates(tileInfo);
            RefreshTileInfo(tileInfo);
            _roleTurnCheckers = (_roleTurnCheckers == _checkerContainer.SecondPlayerCheckers) ?
                                _checkerContainer.FirstPlayerCheckers : _checkerContainer.SecondPlayerCheckers;
        }
    }

    private void SetNewCheckerCoordinates(TileInfo tileInfo)
    {
        var checkerInfo = _selectedChecker.GetComponent<CheckerInfo>();
        checkerInfo.SetNewPosition(tileInfo.Coordinates);
        checkerInfo.ResetHighlight();
        _selectedChecker = null;
    }

    private void RefreshTileInfo(TileInfo tileInfo)
    {
        tileInfo.IsFull = true;
        _previousTileInfo.IsFull = false;
    }

    private Transform GetSelectedChecker(TileInfo tileInfo)
    {
        if (_previousCheckerInfo != null)
            _previousCheckerInfo.ResetHighlight();

        foreach (var checker in _roleTurnCheckers)
        {
            var checkerInfo = checker.GetComponent<CheckerInfo>();
            if (checkerInfo.Coordinates == tileInfo.Coordinates)
            {
                _previousTileInfo = tileInfo;
                _previousCheckerInfo = checkerInfo;
                checkerInfo.SetHighlight(ISelectable.SelectColor);
                return checker;
            }
        }
        return null;
    }

    private bool ConditionsIsMet(Vector2 startPosition, Vector2 targetPosition)
    {
        var deltaX = Mathf.Abs(targetPosition.x - startPosition.x);
        var deltaY = Mathf.Abs(targetPosition.y - startPosition.y);
        //one step diagonal movement
        if (deltaX != 1 || deltaY != 1)
            return false;
        return true;
    }

    private Transform GetIntermediateChecker(Vector2 startPosition, Vector2 targetPosition)
    {
        return null;
    }
}
