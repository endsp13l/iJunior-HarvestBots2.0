using System;
using UnityEngine;

public class HarvestBot : MonoBehaviour
{
	[SerializeField] private float _speed = 2f;

	private Transform _target;
	private bool _isBusy;
	private bool _hasCargo;

	public event Action FlightStarted;
	public event Action FlightEnded;

	public bool IsBusy => _isBusy;
	public bool HasCargo => _hasCargo;

	public void SetTarget(Transform target)
	{
		if (target == null)
			return;

		_isBusy = true;
		_target = target;
		Debug.Log(target);

		FlightStarted?.Invoke();
		MoveToTarget();
	}

	private void MoveToTarget()
	{
		if (_target == null)
			return;

		transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
	}
}
