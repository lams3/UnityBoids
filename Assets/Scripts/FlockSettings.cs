using UnityEngine;

[CreateAssetMenu]
public class FlockSettings : ScriptableObject
{
    // Settings
    [Range(0, 100)]
    public float minSpeed = 2.0f;
    [Range(0, 100)]
    public float maxSpeed = 5.0f;
    [Range(0, 100)]
    public float perceptionRadius = 2.5f;
    [Range(0, 100)]
    public float avoidanceRadius = 1.0f;
    [Range(0, 100)]
    public float maxSteerForce = 3.0f;

    [Range(0, 1)]
    public float alignmentWeight = 1.0f;
    [Range(0, 1)]
    public float cohesionWeight = 1.0f;
    [Range(0, 1)]
    public float separationWeight = 1.0f;
}
