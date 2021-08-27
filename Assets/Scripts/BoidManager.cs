using System.Linq;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    private Boid[] boids;

    private void Start()
    {
        this.boids = FindObjectsOfType<Boid>();
    }

    private void Update()
    {
        foreach (Boid boid in this.boids)
        {
            var visibleNeighbors = this.boids.Where(
                el => Vector3.Distance(boid.transform.position, el.transform.position) <= boid.perceptionRadius
            ).ToList();

            boid.UpdateMotion(visibleNeighbors);
        }
    }
}
