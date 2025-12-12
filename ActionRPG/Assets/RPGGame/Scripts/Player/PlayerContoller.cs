using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class PlayerContoller : MonoBehaviour
    {
        private Transform _refTransform;

        private void Awake()
        {
            _refTransform = transform;
        }
    }
}