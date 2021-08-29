using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class DefaultBoidBrain : ScriptableObject
{
    public virtual List<Boid> FilterFlock(Boid boid, Boid[] allBoids)
    {
        var flock = allBoids.Where(
            el => Vector3.Distance(boid.transform.position, el.transform.position) <= boid.settings.perceptionRadius
        ).ToList();
        flock.Remove(boid);

        return flock;
    }
}
