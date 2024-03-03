using UnityEngine;

public class urmarireCam22 : MonoBehaviour
{
	public Transform Masinuta;
	public Vector3 distantaCamMasina;

	void Update()
	{
		transform.position = Masinuta.position + distantaCamMasina;
	}
}
