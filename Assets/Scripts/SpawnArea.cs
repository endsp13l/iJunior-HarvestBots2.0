using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnArea : MonoBehaviour
{
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public Vector3 GetRandomPosition()
    {
       Vector3 center = _boxCollider.center;
       Vector3 size = _boxCollider.bounds.size;
       Bounds bounds = _boxCollider.bounds;
       
       float xPosition = Random.Range(-bounds.extents.x, bounds.extents.x);
       float yPosition = Random.Range(-bounds.extents.y, bounds.extents.y);
       float zPosition = Random.Range(-bounds.extents.z, bounds.extents.z);

       return new Vector3(xPosition, yPosition, zPosition);
    }
}