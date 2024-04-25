using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class FruitText : MonoBehaviour
    {
        [SerializeField] Fruits _fruitType;
        TextMeshProUGUI _textMesh;
        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
           
        }
        private void OnEnable()
        {
            FruitManager.Instance.OnFruitNumbersChanged += HandleOnFruitsNumberChanged;
        }
        private void Start()
        {
            HandleOnFruitsNumberChanged();
        }
        private void OnDisable()
        {
            FruitManager.Instance.OnFruitNumbersChanged -= HandleOnFruitsNumberChanged;
        }

        private void HandleOnFruitsNumberChanged()
        {
            _textMesh.SetText(FruitManager.Instance.GetFruitNumber(_fruitType).ToString());
        }
    }

}
