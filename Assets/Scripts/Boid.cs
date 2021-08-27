using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    private float separationWeight = 1.0f;

    [SerializeField, Range(0, 1)]
    private float alignmentWeight = 1.0f;

    [SerializeField, Range(0, 1)]
    private float cohesionWeight = 1.0f;

    [Range(0, 10)]
    public float minSpeed = 1.0f;

    [Range(0, 10)]
    public float maxSpeed = 4.0f;

    [SerializeField, Range(0, 10)]
    private float maxSteerForce = 4.0f;

    [Range(0, 10)]
    public float perceptionRadius = 2.0f;

    [SerializeField, Range(0, 10)]
    private float avoidanceRadius = 1.0f;

    [HideInInspector]
    public Vector3 velocity;

    public void UpdateMotion(List<Boid> flock)
    {
        Vector3 acceleration = Vector3.zero;
        if (flock.Count > 0)
        {
            Vector3 offsetToFlockCenter = this.GetFlockCenter(flock) - this.transform.position;

            Vector3 separation = SteerTowards(this.GetAvgAvoidanceHeading(flock)) * this.separationWeight;
            Vector3 alignment = SteerTowards(this.GetAvgFlockHeading(flock)) * this.alignmentWeight;
            Vector3 cohesion = SteerTowards(offsetToFlockCenter) * this.cohesionWeight;
            acceleration = separation + alignment + cohesion;
        }
        
        this.velocity += acceleration * Time.deltaTime;
        float speed = this.velocity.magnitude;
        Vector3 dir = this.velocity / speed;
        speed = Mathf.Clamp(speed, this.minSpeed, this.maxSpeed);
        this.velocity = dir * speed;

        this.transform.position += this.velocity * Time.deltaTime;

        this.transform.forward = this.velocity;
    }

    private Vector3 GetFlockCenter(List<Boid> flock)
    {
        return flock.Aggregate(Vector3.zero, (acc, el) => el.transform.position / flock.Count);
    }

    private Vector3 GetAvgFlockHeading(List<Boid> flock)
    {
        return flock.Aggregate(Vector3.zero, (acc, el) => el.velocity / flock.Count);
    }

    private Vector3 GetAvgAvoidanceHeading(List<Boid> flock)
    {
        Vector3 separation = Vector3.zero;

        foreach (Boid flockMate in flock)
        {
            Vector3 v = this.transform.position - flockMate.transform.position;
            if (v.magnitude < this.avoidanceRadius)
                separation += v.normalized / v.sqrMagnitude;
        }

        return separation;
    }

    private Vector3 SteerTowards(Vector3 vector)
    {
        Vector3 v = vector.normalized * this.maxSpeed - this.velocity;
        return Vector3.ClampMagnitude(v, this.maxSteerForce);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
        Gizmos.DrawSphere(this.transform.position, this.perceptionRadius);

        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.2f);
        Gizmos.DrawSphere(this.transform.position, this.avoidanceRadius);
    }
}
