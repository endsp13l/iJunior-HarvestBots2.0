using UnityEngine;

[RequireComponent(typeof(Scanner))]
public class Base : MonoBehaviour
{
	[SerializeField] private Transform[] _landingPads;
	[SerializeField] private Transform _unloadZone;

	private Scanner _scanner;
	private HarvestBot[] _harvestBots;
	private int _resourceCount;

	public int ResourceCount => _resourceCount;

	private void Awake()
	{
		_scanner = GetComponent<Scanner>();
		_harvestBots = GetComponentsInChildren<HarvestBot>();
	}
}