using UnityEngine;

public class Urmarire : MonoBehaviour
{
    public Transform Masinuta;
    public Vector3 distantaCamMasina;

    void Update()
    {
        transform.position = Masinuta.position + distantaCamMasina;
    }

}
