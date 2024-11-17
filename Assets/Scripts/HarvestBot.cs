using UnityEngine;

public class HarvestBot : MonoBehaviour
{
	[SerializeField] private float _speed;

	private Transform _target;
	private bool _isBusy;
	private bool _hasCargo;

	public bool IsBusy => _isBusy;
	public bool HasCargo => _hasCargo;
}