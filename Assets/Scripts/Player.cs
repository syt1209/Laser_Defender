using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 posChange = _speed * direction * Time.deltaTime;
        transform.position += posChange;
    }
}
