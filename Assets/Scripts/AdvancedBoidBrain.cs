using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class AdvancedBoidBrain : DefaultBoidBrain
{
    public override List<Boid> FilterFlock(Boid boid, Boid[] allBoids)
    {
        var flock = base.FilterFlock(boid, allBoids);
        return flock.Where(el => el.brain == boid.brain).ToList();
    }
}
