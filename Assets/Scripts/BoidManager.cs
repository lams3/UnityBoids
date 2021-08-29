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
            var flock = boid.brain.FilterFlock(boid, this.boids);
            boid.UpdateMotion(flock);
        }
    }
}
