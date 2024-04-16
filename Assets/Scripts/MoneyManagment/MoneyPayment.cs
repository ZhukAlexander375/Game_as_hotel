using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class MoneyPayment : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Collider _collider;    

    [Header("Settings")]
    [SerializeField] private float _duration;
    //[SerializeField] private float _respawnTime = 10f;
    [SerializeField] private float _moneyValue = 100f;

    [Header("Movement settings")]
    [SerializeField] private float _cycleTime = 1;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _collectPoint;
    [SerializeField] private float duration = 1;
    [SerializeField] private float jumpPower = 3;

    private float _startPositionY;

    public static UnityEvent<float> PaymentMoneyCollecter = new();

    private void Start()
    {
        transform.position = _spawnPoint.position;
        StartCoroutine(MoneyPaymentTransfer());        
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, _collectPoint.position) < 0.05f)
        {
            MoneyPaymentMovement();
        }
    }

    private IEnumerator MoneyPaymentTransfer()
    {
        yield return transform.DOJump(_collectPoint.position, jumpPower, 1, duration).WaitForCompletion();
    }

    public void MoneyPickUp(float duration)
    {        
        StartCoroutine(RespawnRoutine(duration));
        MoneyPaymentActive(false);       
    }

    private IEnumerator RespawnRoutine(float duration)
    {        
        yield return new WaitForSeconds(duration);
        MoneyPaymentActive(true);
        ReturnToSpawnPoint();
    }
    private void ReturnToSpawnPoint() 
    {
        transform.position = _spawnPoint.position;
        MoneyPaymentActive(true);
        StartCoroutine(MoneyPaymentTransfer());
    }

    private void MoneyPaymentActive(bool isActive)
    {
        _meshRenderer.enabled = isActive;
        _collider.enabled = isActive;
        MoneyPaymentMovement();
    }

    private void MoneyPaymentMovement()
    {
        transform.DOMoveY(_collectPoint.position.y + 0.7f, _cycleTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InSine);        
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        PaymentMoneyCollecter.Invoke(_moneyValue);
        Debug.Log($"подобрал: {_moneyValue}");
        MoneyPickUp(5f);
    }
}
