using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Table : MonoBehaviour
{

    [SerializeField] private Transform sit;
    private bool _isSitEmpty;
    [SerializeField] private GameObject[] _alienTypes;
    private GameObject _alien;

    private float _cooldownToSpawn;
    private float _cooldown = 10;

    private void Start()
    {
        _cooldownToSpawn = 5;
        _isSitEmpty = true;
    }

    private void Update()
    {
        if (Time.time >= _cooldownToSpawn)
        {
            if (Random.value < 0.25)
            {
                SpawnAliens();
            }
        }
        if (_alien.IsDestroyed() || _alien == null)
        {
            _isSitEmpty = true;
        }
    }

    private void SpawnAliens()
    {
        if (_isSitEmpty)
        {
            _alien = Instantiate(_alienTypes[Random.Range(0, _alienTypes.Length)], sit.position,
            Quaternion.identity);
            _isSitEmpty = false;
            _cooldownToSpawn = Time.time + _cooldown;
        }
    }
}
