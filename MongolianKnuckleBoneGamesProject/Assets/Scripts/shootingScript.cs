using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class shootingScript : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _powerbar;
    private Rigidbody _projectileRB;
    private GameObject _currArrow;
    private GameObject _currArrow2;
    private GameObject _currPowerbar;
    private Vector3 _arrowPointingLocation;
    private float _arrowOscillationRange = 10;
    private float _arrowPointingDistanceFromProjectile = 10;
    private float _arrowRotationOscillationTime = 2f;
    private bool _aiming = true;
    private bool _powering = false;
    private Vector3 _shootDirection;
    private float _shootPower;
    private float _basePower = 1000;

    // Start is called before the first frame update
    void Start()
    {
        _projectileRB = GetComponent<Rigidbody>();
        _currArrow = Instantiate(_arrow, transform.position, Quaternion.identity);
        _currArrow2 = Instantiate(_arrow, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_aiming)
            {
                _aiming = false;
                _powering = true;
                Destroy(_currArrow);
                _currPowerbar = Instantiate(_powerbar, transform.position, Quaternion.identity);
            }
            else if (_powering)
            {
                powerbarScript powerbarScript = _currPowerbar.GetComponent<powerbarScript>();
                if (powerbarScript != null)
                {
                    _shootPower = powerbarScript.getPower();
                    shoot();
                    Destroy(_currPowerbar);
                }

                _powering = false;
                Destroy(this);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_aiming)
        {
            aim();
        }
    }

    private void aim()
    {
        Vector3 direction = new Vector3(Mathf.Sin(Time.time / (_arrowRotationOscillationTime / Mathf.PI)) * _arrowOscillationRange, 0, _arrowPointingDistanceFromProjectile);
        _currArrow2.transform.position = direction;
        _shootDirection = direction - transform.position;
        _currArrow.transform.up = _shootDirection;
    }

    private void shoot()
    {
        _projectileRB.useGravity = true;
        _projectileRB.AddForce(_shootDirection.normalized * _shootPower * _basePower);
        Debug.Log(_shootDirection);
    }
}
