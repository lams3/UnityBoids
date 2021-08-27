using System.Collections.Generic;
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

    private void Update()
    {
        this.transform.position += this.velocity * Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
        Gizmos.DrawSphere(this.transform.position, this.perceptionRadius);
    }
}
