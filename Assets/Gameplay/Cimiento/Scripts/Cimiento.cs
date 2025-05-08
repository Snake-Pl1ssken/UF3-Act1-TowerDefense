using UnityEngine;

public class Cimiento : MonoBehaviour
{
    [SerializeField] GameObject prefabTorreArqueros;
    [SerializeField] GameObject prefabTorreMagica;
    [SerializeField] GameObject prefabTorreCanyones;
    Torre torreConstruida;

    public void ConstruyeTorreArqueros()
    {
        Debug.Log("ContruyeTorreArqueros");
        GameObject nuevaTorre = Instantiate(prefabTorreArqueros, transform.position, transform.rotation);
        torreConstruida = nuevaTorre.GetComponent<Torre>();
    }

    public void ConstruyeTorreMagica()
    {
        Debug.Log("ContruyeTorreArqueros");
    }

    public void ConstruyeTorreCanyones()
    {
        Debug.Log("ContruyeTorreArqueros");
    }

    public bool HayTorreContruida()
    {
        return torreConstruida;
    }
}
