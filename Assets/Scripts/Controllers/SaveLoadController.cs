using WorldGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public class SaveLoadController : MonoBehaviour
{
    public static SaveLoadController Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is already an instance of SaveLoadController.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    [ContextMenu("Save")]
    public void Save()
    {
        // create an empty dictionary
        SerializableDictionary<Coord, SerializableList<CellDataSO>> dict = MapController.Instance.Map.Save.cells;


        // convert to JSON
        string json = JsonHelper.ToJson(dict);

        Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/save.json", json);
        
    }
}


