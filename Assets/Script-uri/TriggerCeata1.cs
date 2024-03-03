using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCeata1 : MonoBehaviour
{
	public float FogDens = 0.5f;

	private void OnTriggerEnter()
	{
		if (FindObjectOfType<Ciocnire>().lovit == true)
		{
			gameObject.GetComponent<BoxCollider>().isTrigger = false;
		}
		else
			RenderSettings.fogDensity = FogDens;
	}
}
