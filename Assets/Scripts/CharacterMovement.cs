using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Variables;

public class CharacterMovement : NetworkBehaviour
{

    [SerializeField] FloatVariable _moveSpeed;
    [SerializeField] FloatReference _startMoveSpeed;

    Vector2 _movement;


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(_movement.x * Time.deltaTime * _moveSpeed.Value, _movement.y * Time.deltaTime *_moveSpeed.Value, 0);
    }

    [Client(RequireOwnership = true)]
    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
}
