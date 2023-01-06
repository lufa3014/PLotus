using WorldGrid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    Coord _lastKnownCoord;
    
    public ObjectDataSO objectData;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            
            Vector3 lastKnownPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            _lastKnownCoord = new Coord((int)lastKnownPosition.x, (int)lastKnownPosition.y);
            Debug.Log(_lastKnownCoord);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Coord currentCoord = new Coord((int)currentPosition.x, (int)currentPosition.y);
            Debug.Log(currentCoord);
            
            if (_lastKnownCoord.x < currentCoord.x)
            {
                for (int x = _lastKnownCoord.x; x <= currentCoord.x; x++)
                {
                    if (_lastKnownCoord.y < currentCoord.y)
                    {
                        for (int y = _lastKnownCoord.y; y <= currentCoord.y; y++)
                        {
                            Cell cell = MapController.Instance.Map.GetTileAt(x, y);
                            cell.ObjectData = objectData;
                        }
                    }
                    else
                    {
                        for (int y = currentCoord.y; y <= _lastKnownCoord.y; y++)
                        {
                            Cell cell = MapController.Instance.Map.GetTileAt(x, y);
                            cell.ObjectData = objectData;
                        }
                    }
                }
            }
            else
            {
                for (int x = currentCoord.x; x <= _lastKnownCoord.x; x++)
                {
                    if (_lastKnownCoord.y < currentCoord.y)
                    {
                        for (int y = _lastKnownCoord.y; y <= currentCoord.y; y++)
                        {
                            Cell cell = MapController.Instance.Map.GetTileAt(x, y);
                            cell.ObjectData = objectData;
                        }
                    }
                    else
                    {
                        for (int y = currentCoord.y; y <= _lastKnownCoord.y; y++)
                        {
                            Cell cell = MapController.Instance.Map.GetTileAt(x, y);
                            cell.ObjectData = objectData;
                        }
                    }
                }
            }
        }
    }
}