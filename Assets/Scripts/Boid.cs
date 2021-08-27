using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [Range(0, 10)]
    public float minSpeed = 1.0f;

    [Range(0, 10)]
    public float maxSpeed = 4.0f;

    [Range(0, 10)]
    public float perceptionRadius = 2.0f;

    [HideInInspector]
    public Vector3 velocity;

    public void UpdateMotion(List<Boid> visibleNeighbors)
    {
        Vector3 acceleration = Vector3.zero;
        
        if (visibleNeighbors.Count > 0)
        {
            Vector3 targetVelocity = visibleNeighbors.Aggregate(Vector3.zero, (acc, el) => acc + el.velocity / visibleNeighbors.Count);
            acceleration = targetVelocity - this.velocity;
        }

        this.velocity += acceleration * Time.deltaTime;
        this.transform.position += this.velocity * Time.deltaTime;

        this.transform.forward = this.velocity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
        Gizmos.DrawSphere(this.transform.position, this.perceptionRadius);
    }
}
