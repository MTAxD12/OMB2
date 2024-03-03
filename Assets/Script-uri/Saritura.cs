using UnityEngine;
using System.Collections;

public class Saritura : MonoBehaviour
{
	[Range(1, 100)]
	public float vitezaSaritura;

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			GetComponent<Rigidbody>().velocity = Vector3.up * vitezaSaritura;
		}
	}
}