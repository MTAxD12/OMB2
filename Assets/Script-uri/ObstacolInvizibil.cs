using UnityEngine;

public class ObstacolInvizibil : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        if (FindObjectOfType<Ciocnire>().lovit == false)
        {
            FindObjectOfType<GameManager>().Restart();
        }   
    }
}
