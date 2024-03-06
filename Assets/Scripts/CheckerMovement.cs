using UnityEngine;

public class CheckerMovement : MonoBehaviour
{
    [SerializeField] private CheckerContainer _checkerContainer;
    [SerializeField] private InputHandler _inputHandler;

    private TileInfo _previousTileInfo;
    private CheckerInfo _previousCheckerInfo;

    private Transform _selectedChecker;

    public void AddTileListener()
    {
        _inputHandler.OnSelectedTile += CheckSelectedTile;
    }

    private void CheckSelectedTile(Transform tile)
    {
        var tileInfo = tile.GetComponent<TileInfo>();
        if (!tileInfo.IsFull)
        {
            if (_selectedChecker is null)
                return;
            else
            {
                SetNewCheckerCoordinates(tileInfo);
                tileInfo.IsFull = true;
                _previousTileInfo.IsFull = false;
            }
        }
        else
        {
            _selectedChecker = GetSelectedChecker(tileInfo);
        }
    }
    private void SetNewCheckerCoordinates(TileInfo tileInfo)
    {
        var checkerInfo = _selectedChecker.GetComponent<CheckerInfo>();
        checkerInfo.SetNewPosition(tileInfo.Coordinates);
        checkerInfo.ResetHighlight();
        _selectedChecker = null;
    }

    private Transform GetSelectedChecker(TileInfo tileInfo)
    {
        if (_previousCheckerInfo != null)
            _previousCheckerInfo.ResetHighlight();

        foreach (var checker in _checkerContainer.SecondPlayerCheckers)
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
}
