using UnityEngine;

public class Cimiento : MonoBehaviour
{
    [Header("Torre Arqueros")]
    [SerializeField] GameObject prefabTorreArqueros;
    [SerializeField] GameObject prefabTorreArquerosLv1;
    [SerializeField] GameObject prefabTorreArquerosLv2;

    [Header("Torre Magica")]
    [SerializeField] GameObject prefabTorreMagica;
    [SerializeField] GameObject prefabTorreMagicaLv1;
    [SerializeField] GameObject prefabTorreMagicaLv2;

    [Header("Torre Cañones")]
    [SerializeField] GameObject prefabTorreCanyones;
    [SerializeField] GameObject prefabTorreCanyonesLv1;
    [SerializeField] GameObject prefabTorreCanyonesLv2;

    Torre torreConstruida;
    GameObject nuevaTorre;

    public void ConstruyeTorreArqueros()
    {
        Debug.Log("ContruyeTorreArqueros");
        nuevaTorre = Instantiate(prefabTorreArqueros, transform.position, transform.rotation);
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
