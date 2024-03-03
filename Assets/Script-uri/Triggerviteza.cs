using UnityEngine;

public class Triggerviteza : MonoBehaviour
{

    void OnTriggerEnter()
    {
        if (MainMenu.isHardcore == false)
        {
            if (FindObjectOfType<Ciocnire>().lovit == false)
            {
                FindObjectOfType<Miscare>().vitezaFata = 0;
            }
        }
		else
		{
            if (FindObjectOfType<CiocnireHardcore>().lovit == false)
            {
                FindObjectOfType<Miscare>().vitezaFata = 0;
            }
        }
    }
}
