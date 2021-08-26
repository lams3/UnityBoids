using UnityEngine;

public class Boid : MonoBehaviour
{
    [Range(0, 10)]
    public float minSpeed = 1.0f;

    [Range(0, 10)]
    public float maxSpeed = 4.0f;

    [HideInInspector]
    public Vector3 velocity;


    private void Update()
    {
        this.transform.position += this.velocity * Time.deltaTime;
    }
}
