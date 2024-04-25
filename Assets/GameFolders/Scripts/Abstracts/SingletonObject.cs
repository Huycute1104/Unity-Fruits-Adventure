using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts
{
    public class SingletonObject<T> : MonoBehaviour
    {
        public static T Instance { get; private set; }
        protected void SingletonThisObject(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

}
