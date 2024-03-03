using UnityEngine;

public class Triggerlumini : MonoBehaviour
{
    public GameObject masinaPol1;
    public GameObject masinaPol2;
    public GameObject masinaPol3;

    public GameObject canvas;

    void OnTriggerEnter()
    {
        if (MainMenu.isHardcore == false)
        {
            if (FindObjectOfType<Ciocnire>().lovit == false)
            {
                masinaPol1.SetActive(true);
                masinaPol2.SetActive(true);
                masinaPol3.SetActive(true);
            }
        }
		else
		{
            if (FindObjectOfType<CiocnireHardcore>().lovit == false)
            {
                masinaPol1.SetActive(true);
                masinaPol2.SetActive(true);
                masinaPol3.SetActive(true);
            }
        }
    }
}
