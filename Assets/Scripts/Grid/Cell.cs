using System;
using UnityEngine;

namespace MyGrid
{
    public class Cell
    {
        public event EventHandler OnGroundDataChanged;
        public event EventHandler OnObjectDataChanged;
        public event EventHandler OnItemDataChanged;

        private GroundDataSO _groundData;
        public GroundDataSO GroundData
        {
            get => _groundData;
            set
            {
                if (_groundData != value)
                {
                    _groundData = value;
                    OnGroundDataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private ObjectDataSO _objectData;
        public ObjectDataSO ObjectData
        {
            get => _objectData;
            set
            {
                if (_objectData != value)
                {
                    _objectData = value;
                    OnObjectDataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private ItemDataSO _itemData;
        public ItemDataSO ItemData
        {
            get => _itemData;

            set
            {
                if (_itemData != value)
                {
                    _itemData = value;
                    OnItemDataChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}