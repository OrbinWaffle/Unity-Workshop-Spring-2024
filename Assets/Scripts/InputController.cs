using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class InputController : MonoBehaviour{
    PlayerController PC;
    CameraController CC;
    public bool canMove = true;

    void Start(){
        PC = GetComponent<PlayerController>();
    }
    void Update(){
        // if we can't move, set player movement vector to zero
        if(canMove == false)
        {
            PC.UpdateMoveVector(Vector2.zero);
            return;
        }
        // otherwise, set movement vector to input axis, normalized
        Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        PC.UpdateMoveVector(moveVector);

        // call jump
        if (Input.GetButtonDown("Jump")){
            PC.Jump();
        }

        // get look vector (unused)
        Vector2 lookVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}