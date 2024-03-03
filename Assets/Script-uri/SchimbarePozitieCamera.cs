using UnityEngine;

public class SchimbarePozitieCamera : MonoBehaviour
{
	public GameObject camera2;
	public Rigidbody rbMasinuta;


	void OnTriggerEnter()
	{
		if (MainMenu.isHardcore == false) {
		if (FindObjectOfType<Ciocnire>().lovit == false)
		{
				if (rbMasinuta.position.x > 0)
				{
					camera2.GetComponent<urmarireCam22>().enabled = true;
					camera2.GetComponent<urmarireCam2>().enabled = false;
					camera2.transform.eulerAngles = new Vector3(
					camera2.transform.eulerAngles.x,
					camera2.transform.eulerAngles.y + 300,
					camera2.transform.eulerAngles.z);
				}
			}
		}
		else
		{
			if (FindObjectOfType<CiocnireHardcore>().lovit == false)
			{
				if (rbMasinuta.position.x > 0)
				{
					camera2.GetComponent<urmarireCam22>().enabled = true;
					camera2.GetComponent<urmarireCam2>().enabled = false;
					camera2.transform.eulerAngles = new Vector3(
					camera2.transform.eulerAngles.x,
					camera2.transform.eulerAngles.y + 300,
					camera2.transform.eulerAngles.z);
				}
			}
		}
	}
}
