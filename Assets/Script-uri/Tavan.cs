using UnityEngine;

public class Tavan : MonoBehaviour
{

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (MainMenu.isHardcore == false)
        {
            if (collisionInfo.tag == "Player")
            {
                FindObjectOfType<GameManager>().Restart();
            }
        }
        else
        {
            if (collisionInfo.tag == "Player")
            {
                FindObjectOfType<GameManager>().RestartHardcore();
            }
        }
    }
}
