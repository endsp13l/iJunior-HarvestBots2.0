using UnityEngine;

public class Box : MonoBehaviour
{
	private bool _isScanned;

	public bool IsScanned => _isScanned;

	public void Scan() => _isScanned = true;
}