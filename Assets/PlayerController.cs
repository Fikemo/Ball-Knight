using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // private Vector2 move;
    public float move;
    public float jump;
    public float torque;
    public float moveStrength;
    public float jumpStrength;
    public float torqueStrength;
    public Vector2 speed;

    private void OnMove(InputValue value) {
        move = value.Get<Vector2>().x * moveStrength;
        torque = - value.Get<Vector2>().x * torqueStrength;
    }

    private void OnJump(InputValue value) {
        if (value.isPressed && IsGroundedRaycast()) {
            jump = jumpStrength;
            Debug.Log(jump);
        }
    }

    private void FixedUpdate() {

        if (IsGroundedRaycast()) {
            // if grounded, add jump force
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jump));
        } else {
            // if in air, remove jump force
            // add move force to move in air
            jump = 0.0f;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(move, 0.0f) * Time.fixedDeltaTime);
        }

        // if grounded or in air, add rotational force (torque)
        GetComponent<Rigidbody2D>().AddTorque(torque * Time.fixedDeltaTime);
    }

    private bool IsGroundedRaycast() {
        CircleCollider2D circleCollider2D = GetComponent<CircleCollider2D>();
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(circleCollider2D.bounds.center, Vector2.down, circleCollider2D.bounds.extents.y + 0.01f, mask);
        return hit.collider != null;
    }
}
