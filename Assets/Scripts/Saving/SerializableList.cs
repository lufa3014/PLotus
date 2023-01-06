using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableList<T> : List<T>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<T> items = new();

    // Save the list to a serialized field
    public void OnBeforeSerialize()
    {
        items.Clear();
        foreach (T item in this)
        {
            items.Add(item);
        }
    }

    // Load the list from a serialized field
    public void OnAfterDeserialize()
    {
        Clear();
        foreach (T item in items)
        {
            Add(item);
        }
    }
}