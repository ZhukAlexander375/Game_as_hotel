using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleaningZone : MonoBehaviour
{
    [Header("Components")]    
    [SerializeField] private Collider _collider;
    [SerializeField] private bool _isCleaning = false;
    [SerializeField] private float _timer = 0f;
    public static UnityEvent EndClean = new();

    private void FixedUpdate()
    {
        if (_isCleaning)
        {
            CleanTimer();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        _isCleaning = true;
        Debug.Log($"нахожусь в зоне уборки");
        //MoneyPickUp(5f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        _isCleaning = false;
        _timer = 0f;
        Debug.Log($"Вышел из зоны");
    }

    private void CleanTimer()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= 2f)
        {
            EndCleaning();
        }
    }

    private void EndCleaning()
    {
        Debug.Log("End");
        _isCleaning = false;
        _timer = 0f;
        gameObject.SetActive(false);
        EndClean.Invoke();
    }
}
