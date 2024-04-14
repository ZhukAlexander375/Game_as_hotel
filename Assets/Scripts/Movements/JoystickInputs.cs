using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickInputs : InputsBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Image _knob;
    [SerializeField] private float _maxDistance = 100;

    private Vector2 _startPosition;
    private Vector2 _output;

    public override Vector2 Direction()
    {        
        return _output;
    }  

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _output = Vector2.zero;

        _knob.enabled = true;
        _knob.transform.position = eventData.position;
        _startPosition = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _output = Vector2.zero;
        _knob.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var raw = eventData.position - _startPosition;

        _knob.transform.position = eventData.position;
        _knob.transform.position = raw.magnitude > _maxDistance
            ? _startPosition + raw.normalized * _maxDistance
            : eventData.position;
        
        _output = (_knob.transform.position - new Vector3(_startPosition.x, _startPosition.y)) / _maxDistance;
    }
}
