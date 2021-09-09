using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 20.0f;
    
    private Vector3 velocity;

    public void MoveCallback(InputAction.CallbackContext ctx)
    {
        Vector2 direction = Vector2.ClampMagnitude(ctx.ReadValue<Vector2>(), 1.0f);
        this.velocity = (direction.x * Vector3.right + direction.y * Vector3.forward) * this.maxSpeed;
        this.velocity = Vector3.ClampMagnitude(this.velocity, this.maxSpeed);
    }

    private void Update()
    {
        this.transform.position += this.velocity * Time.deltaTime;
    }

}
