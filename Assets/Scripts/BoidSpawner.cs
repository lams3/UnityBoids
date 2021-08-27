using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    [SerializeField]
    private Boid boidPrefab;

    [SerializeField]
    private int numBoids;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 size;

    private void Awake()
    {
        Vector3 min = this.transform.position - this.size / 2.0f;
        Vector3 max = this.transform.position + this.size / 2.0f;
        for (int i = 0; i < this.numBoids; i++)
        {
            var boid = Instantiate(this.boidPrefab);
            boid.transform.position = new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                Random.Range(min.z, max.z)
            );
            boid.velocity = Random.Range(boid.settings.minSpeed, boid.settings.maxSpeed) * boid.transform.forward;
            boid.target = this.target;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        Gizmos.DrawCube(this.transform.position, this.size);
    }
}
