using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HarvestBot))]
[RequireComponent(typeof(Animator))]
public class HarvestBotView : MonoBehaviour
{
	private Animator _animator;
	private HarvestBot _harvestBot;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_harvestBot = GetComponent<HarvestBot>();
	}

	private void OnEnable()
	{
		_harvestBot.FlightStarted += OnFlight;
		_harvestBot.FlightEnded += OnLand;
	}

	private void OnFlight()
	{
		_animator.SetBool("IsActive", true);
	}

	private void OnLand()
	{
		_animator.SetBool("IsActive", false);
	}

	private void OnDisable()
	{
		_harvestBot.FlightStarted -= OnFlight;
		_harvestBot.FlightEnded -= OnLand;
	}
}