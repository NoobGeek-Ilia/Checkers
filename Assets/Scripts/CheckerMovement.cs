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
        if (tileInfo.IsFull)
        {
            _selectedChecker = GetSelectedChecker(tileInfo);
            return;
        }

        if (_selectedChecker == null)
            return;

        if (IsDiagonalMove(_previousTileInfo.Coordinates, tileInfo.Coordinates))
        {
            SetNewCheckerCoordinates(tileInfo);
            RefreshTileInfo(tileInfo);
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

    private bool IsDiagonalMove(Vector2 startPosition, Vector2 targetPosition)
    {
        float deltaX = Mathf.Abs(targetPosition.x - startPosition.x);
        float deltaY = Mathf.Abs(targetPosition.y - startPosition.y);

        return deltaX == deltaY;
    }
}
