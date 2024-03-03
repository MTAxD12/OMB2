using UnityEngine;

public class urmarireCam2 : MonoBehaviour
{
    public Transform Masinuta;
    public Vector3 distantaCamMasina;

    void Update()
    {
        transform.position = Masinuta.position + distantaCamMasina;
    }
}
