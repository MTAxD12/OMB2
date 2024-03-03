using UnityEngine.SceneManagement;
using UnityEngine;

public class IntrareRonaldo : MonoBehaviour
{
	private void OnTriggerEnter(Collider collisionInfo)
	{
		if (collisionInfo.tag == "Player")
		{
			if (MainMenu.isHardcore == false)
			{
				if (FindObjectOfType<Ciocnire>().lovit == false)
				{
					SceneManager.LoadScene(10);
				}
			}
			else
			{
				if (FindObjectOfType<CiocnireHardcore>().lovit == false)
				{
					SceneManager.LoadScene(10);
				}
			}
		}
	}
}
