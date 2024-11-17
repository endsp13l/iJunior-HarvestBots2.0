using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
	private Queue<Transform> _scannedObjects = new Queue<Transform>();

	public Transform GetTarget()
	{
		if (_scannedObjects.Count <= 0)
		{
			Scan();
			return null;
		}

		return _scannedObjects.Dequeue();
	}

	private void Scan()
	{
		Box[] boxes = FindObjectsOfType<Box>();

		foreach (Box box in boxes)
		{
			if (box.IsScanned == false)
			{
				_scannedObjects.Enqueue(box.transform);
				box.Scan();
			}
		}
	}
}