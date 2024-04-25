using Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class FruitManager : SingletonObject<FruitManager>
    {
        Dictionary<Fruits, int> _fruits = new Dictionary<Fruits, int>();
        public event System.Action OnFruitNumbersChanged;
        private void Awake()
        {
            SingletonThisObject(this);
            ResetFruits();
        }
        private void Start()
        {
            OnFruitNumbersChanged?.Invoke();
        }
        public void ResetFruits()
        {
            _fruits.Clear();
            _fruits.Add(Fruits.Banana, 0);
            _fruits.Add(Fruits.Pineapple, 0);
            _fruits.Add(Fruits.Melon, 0);
            OnFruitNumbersChanged?.Invoke();
        }
        public int GetFruitNumber(Fruits fruit)
        {
            return _fruits[fruit];
        }
        public bool AreThereEnoughFruit(Fruits fruit, int limit)
        {
            if (_fruits[fruit] >= limit)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void IncreaseFruitNumber(Fruits fruit)
        {
            _fruits[fruit]++;
            OnFruitNumbersChanged?.Invoke();
        }
        public void DecreaseFruitNumber(Fruits fruit, int number)
        {
            _fruits[fruit] = _fruits[fruit] - number;
            if (_fruits[fruit] < 0)
            {
                _fruits[fruit] = 0;
            }
            OnFruitNumbersChanged?.Invoke();
        }
        private void Reset()
        {
            
        }
        //private void Update()
        //{
        //    //Delete update
        //    Debug.Log("-------------------------------");
        //    Debug.Log("-------------------------------");
        //    Debug.Log("-------------------------------");
        //    Debug.Log("-------------------------------");
        //    Debug.Log("-------------------------------");
        //    Debug.Log("Melon " + _fruits[Fruits.Melon]);
        //    Debug.Log("Banana" + _fruits[Fruits.Banana]);
        //    Debug.Log("Pineapple" + _fruits[Fruits.Pineapple]);

        //}
    }

}
