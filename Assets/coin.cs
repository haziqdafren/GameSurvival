using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private LevelController _levelController;

    private void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            _levelController.AddScore();

            Destroy(gameObject);
        }
    }
}
