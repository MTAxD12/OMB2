using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool jocTerminat = false;
    public bool jocPierdut = false;

    public float restartDelay = 2f;
    public float sfarsitDelay = 100f;


	private void Start()
	{

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


	private void FixedUpdate()
    {
        if (Input.GetKey("r"))
        {
            if (MainMenu.isHardcore == false)
            {
                if (PauseMenu.GameIsPaused == false)
                {
                    Restart();
                }
            }
            else
            {
                if (PauseMenu.GameIsPaused == false)
                {
                    RestartHardcore();
                }
            }
        }
    }

	public void CompleteLevel()
    {
        FindObjectOfType<CamSwitch>().SchimbareCameraIncSf();
        Invoke("IncarcareScena", sfarsitDelay);
        FindObjectOfType<SunetFundal>().SfarsitNivel();
        jocTerminat = true; 
    }
    
    public void IncarcareScena()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }

    public void EndGame()
    {
        if (jocPierdut == false)
        {
            FindObjectOfType<Miscare>().enabled = false;
            DeathScript.deathValue += 1;
            Invoke("Restart", restartDelay);
            jocPierdut = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<SunetFundal>().StartMuzica();
    }
    

    public void EndGameHardcore()
	{
        if (jocPierdut == false)
		{
            FindObjectOfType<Miscare>().enabled = false;
            DeathScript.deathValue += 1;
            Invoke("RestartHardcore", restartDelay);
            jocPierdut = true;
		}
	}
    public void RestartHardcore()
	{
        SceneManager.LoadScene(1);
        FindObjectOfType<SunetFundal>().StartMuzica();

    }
    public void CompleteGameHardcore()
	{
        FindObjectOfType<CamSwitch>().SchimbareCameraIncSf();
        Invoke("IncarcareScenaHardcore", sfarsitDelay);
        FindObjectOfType<SunetFundal>().SfarsitNivel();
        jocTerminat = true;
    }
    public void IncarcareScenaHardcore()
	{
        SceneManager.LoadScene(12);
	}
}
