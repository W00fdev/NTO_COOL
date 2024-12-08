using System;
using UnityEngine;

namespace UI
{
    public class FloatingSpawner : MonoBehaviour
    {
        [SerializeField] private FloatingValue _valuePaseka;
        [SerializeField] private FloatingValue _valueSawmill;
        [SerializeField] private FloatingValue _valueStonemill;
        [SerializeField] private Transform _valuePoint;

        public void Spawn(ProductionType type)
        {
            switch (type)
            {
                case ProductionType.Sawmill:
                    GameObject.Instantiate(_valueSawmill, _valuePoint.position, Quaternion.identity);
                    break;
                case ProductionType.Stonemill:
                    GameObject.Instantiate(_valueStonemill, _valuePoint.position, Quaternion.identity);
                    break;
                case ProductionType.Paseka:
                    GameObject.Instantiate(_valuePaseka, _valuePoint.position, Quaternion.identity);
                    break;
            }
        }
    }
}