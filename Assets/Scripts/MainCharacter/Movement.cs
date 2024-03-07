using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private AnimationsManager animationsManager;
    [SerializeField] private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Vector3 _input;
    private float secondsWalking = 0;
    private bool run = false;

    private void Update() {
        if(!gameObject.GetComponent<Combat>().Attacking()){
            GatherInput();
            Look();
        } else {
            StopWalking();
        }
    }

    private void FixedUpdate() {
        if(!gameObject.GetComponent<Combat>().Attacking())
            Move();
    }

    private void GatherInput() {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look() {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move() {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
        if(_input.normalized.magnitude != 0 && secondsWalking == 0){
            animationsManager.startWalk();
        } 
        if(_input.normalized.magnitude != 0){
            secondsWalking += Time.deltaTime;
        }
        if(_input.normalized.magnitude == 0 && secondsWalking != 0){
            secondsWalking = 0;
            animationsManager.stopActivity();
            run = false;
        }
        if(_input.normalized.magnitude != 0 && secondsWalking >= 3 && !run){
            animationsManager.startRun();
            run = true;
        }
    }

    private void StopWalking(){
        _input = Vector3.zero;
    }
}