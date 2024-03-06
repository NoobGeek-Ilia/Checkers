using UnityEngine;

public class CheckerMovement : MonoBehaviour
{
    [SerializeField] private CheckerContainer _checkerContainer;
    [SerializeField] private InputHandler _inputHandler;

    private TileInfo _previousTileInfo;
    private Transform _selectedChecker;

    public void AddTileListener()
    {
        _inputHandler.OnSelectedTile += CheckSelectedTile;
    }

    private void CheckSelectedTile(Transform tile)
    {
        Debug.Log("OK");
        var tileInfo = tile.GetComponent<TileInfo>();
        if (!tileInfo.IsFull)
        {
            Debug.Log("OK1");
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
            Debug.Log("OK2");
            _selectedChecker = GetSelectedChecker(tileInfo);
        }
    }
    private void SetNewCheckerCoordinates(TileInfo tileInfo)
    {
        Debug.Log("OK3");
        _selectedChecker.GetComponent<CheckerInfo>().Init(tileInfo.Coordinates);
        _selectedChecker = null;
    }

    private Transform GetSelectedChecker(TileInfo tileInfo)
    {
        foreach (var checker in _checkerContainer.FirstPlayerCheckers)
        {
            var checkerInfo = checker.GetComponent<CheckerInfo>();
            if (checkerInfo.Coordinates == tileInfo.Coordinates)
            {
                Debug.Log("OK4");
                _previousTileInfo = tileInfo;
                return checker;
            }
        }
        Debug.Log("OK5");
        return null;
    }
}
