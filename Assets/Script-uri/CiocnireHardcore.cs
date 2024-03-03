using UnityEngine;

public class CiocnireHardcore : MonoBehaviour
{
    public AudioSource sunetCiocnire;
    private bool sunetRedat = false;
    public bool lovit = false;

	private void Update()
	{
	}
	private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacol")
        {
            FindObjectOfType<GameManager>().EndGameHardcore();
            if (sunetRedat == false)
            {
                sunetCiocnire.Play();
                sunetRedat = true;
            }
            lovit = true;
        }
    }
}
