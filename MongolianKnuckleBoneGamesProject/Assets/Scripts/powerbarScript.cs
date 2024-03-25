using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerbarScript : MonoBehaviour
{
    [SerializeField] private Transform _powerMeterTransform;
    private float _powerMeterRange;
    private float _powerMeterOscillationTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _powerMeterRange = ((transform.localScale.y / 2.0f) / transform.localScale.y) - (_powerMeterTransform.localScale.y / 2.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _powerMeterTransform.localPosition = new Vector3(0, Mathf.Sin(Time.time / (_powerMeterOscillationTime / Mathf.PI)) * _powerMeterRange, _powerMeterTransform.localPosition.z);
    }

    public float getPower()
    {
        float scaledPower = (_powerMeterTransform.localPosition.y + _powerMeterRange) / (2 * _powerMeterRange);
        return scaledPower;
    }
}
