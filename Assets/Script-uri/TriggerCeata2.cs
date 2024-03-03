using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCeata2 : MonoBehaviour
{
	public float FogDens = 0.5f;

	private void OnTriggerEnter()
	{
		RenderSettings.fogDensity = FogDens;
	}
}
