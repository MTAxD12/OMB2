using UnityEngine;

public class TriggerTrigger : MonoBehaviour
{
	private void OnTriggerEnter()
	{
		if (MainMenu.isHardcore == false)
		{
			if (FindObjectOfType<Ciocnire>().lovit == true)
			{
				gameObject.GetComponent<BoxCollider>().isTrigger = false;
			}
		}
		else
		{
			if (FindObjectOfType<CiocnireHardcore>().lovit == true)
			{
				gameObject.GetComponent<BoxCollider>().isTrigger = false;
			}
		}
	}
}