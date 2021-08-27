using System.Linq;
using UnityEngine;

public class BoidCage : MonoBehaviour
{
    [SerializeField]
    private Vector3 size;

    private Boid[] boids;

    private void Start()
    {
        Bounds bounds = new Bounds(this.transform.position, this.size);
        this.boids = FindObjectsOfType<Boid>().Where(el => bounds.Contains(el.transform.position)).ToArray();
    }

    private void Update()
    {
        foreach(Boid boid in this.boids)
        {
            Bounds bounds = new Bounds(this.transform.position, this.size);
            Vector3 position = boid.transform.position;
            for (int i = 0; i < 3; i++)
            {
                if (position[i] < bounds.min[i])
                    position[i] = bounds.max[i];
                else if (position[i] > bounds.max[i])
                    position[i] = bounds.min[i];
            }
            boid.transform.position = position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.2f);
        Gizmos.DrawCube(this.transform.position, this.size);
    }
}
