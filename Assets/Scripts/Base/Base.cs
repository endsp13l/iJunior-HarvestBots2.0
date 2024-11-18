using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Scanner))]
public class Base : MonoBehaviour
{
	[SerializeField] private Transform[] _landingPads;
	[SerializeField] private Transform _unloadZone;

	private Scanner _scanner;
	private HarvestBot[] _harvestBots;
	private int _resourceCount;
	private Coroutine _coroutine;
	private float _harvestDelay = 3f;

	public int ResourceCount => _resourceCount;

	private void Awake()
	{
		_scanner = GetComponent<Scanner>();
		_harvestBots = GetComponentsInChildren<HarvestBot>();
	}

	private void Start()
	{
		_coroutine = StartCoroutine(HarvestResources());
	}

	private IEnumerator HarvestResources()
	{
		WaitForSeconds wait = new WaitForSeconds(_harvestDelay);

		while (true)
		{
			TrySendBot();
			yield return wait;
		}
	}

	private void TrySendBot()
	{
		HarvestBot currentBot = GetFreeBot();

		if (currentBot)
			currentBot.SetTarget(_scanner.GetTarget());
		else
			Debug.LogError("No available harvest bots!");
	}

	private HarvestBot GetFreeBot()
	{
		foreach (HarvestBot bot in _harvestBots)
			if (bot.IsBusy == false)
				return bot;

		return null;
	}
}