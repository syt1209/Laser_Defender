using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configuration parameters
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _padding = 1f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _laserSpeed = 10f;

    
    float xMin, xMax, yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

   
    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 posChange = _speed * direction * Time.deltaTime;
        var newPosX = Mathf.Clamp((posChange + transform.position).x, xMin, xMax);
        var newPosY = Mathf.Clamp((posChange + transform.position).y, yMin, yMax);
        transform.position = new Vector3(newPosX, newPosY, 0);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))  // space or left mouse
        {
            GameObject laser = Instantiate(_laserPrefab, transform.position, Quaternion.identity) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _laserSpeed);
            Debug.Log(laser.GetComponent<Rigidbody2D>().velocity);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _padding;
    }

}
