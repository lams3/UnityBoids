using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 size;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        Gizmos.DrawCube(this.transform.position, this.size);
    }
}
