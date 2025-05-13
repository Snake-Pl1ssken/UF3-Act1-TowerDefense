using UnityEngine;
using DG.Tweening;

public partial class Proyectil : MonoBehaviour
{
    [SerializeField] float danyoImpactoDirecto;
    [SerializeField] float radioDanyoArea;
    [SerializeField] float danyoAreaEnOrigen;
    [SerializeField] float danyoAreaEnBorde;
    [SerializeField] int subProyectilesAGenerar;
    [SerializeField] float radioSubProyectiles;
    [SerializeField] GameObject prefabSubProyectil;
    [SerializeField] string[] tagsAfectados;

    [SerializeField] float tiempoMovimiento = 1f;
    //[SerializeField] float velocida = 1f;

    [SerializeField] float alturaSaltoSubProyectil = 5f;

    public void Init(Vector3 puntoInicial, Vector3 puntoFinal, float alturaSalto)
    { 
        transform.position = puntoInicial;
        transform.DOJump(puntoFinal, alturaSalto, 1, tiempoMovimiento).
            OnComplete(() => RealizaLaDestruccion());

        //transform.DOJump(puntoFinal, alturaSalto, 1, tiempoMovimiento).SetSpeedBased();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ColliderEsAfectable(other))
        {
            other.GetComponent<IGolpeable>()?.RecibeDanyo(danyoImpactoDirecto);
            RealizaLaDestruccion();
        }
        else if (!other.CompareTag("Cimiento"))
        {
            RealizaLaDestruccion();
        }
    }
    void RealizaLaDestruccion()
    {
        DanyaPorDestruccion();
        GeneraSubProyectil();
        Destroy(this.gameObject);
    }


    private void GeneraSubProyectil()
    {
        for (int i = 0; i < subProyectilesAGenerar; i++)
        {
            Vector2 posicionAleatoriaXY = Random.insideUnitCircle;
            Vector3 posicionAleatoria = new Vector3(posicionAleatoriaXY.x, 0f, posicionAleatoriaXY.y);

            posicionAleatoria *= radioSubProyectiles;
            posicionAleatoria += transform.position;

            Vector3 spawnPoint = new Vector3(posicionAleatoria.x, posicionAleatoria.y + 10, posicionAleatoria.z);

            GameObject newProyectil = Instantiate(prefabSubProyectil);
            newProyectil.GetComponent<Proyectil>().Init(
                spawnPoint, posicionAleatoria, alturaSaltoSubProyectil);
        }
    }

    private void DanyaPorDestruccion()
    {
        Collider[] objetosCercanos = Physics.OverlapSphere(transform.position, radioDanyoArea);
        foreach (Collider c in objetosCercanos)
        {
            if (ColliderEsAfectable(c))
            {
                float distanciaAlCentro = 
                    Vector3.Distance(c.transform.position, transform.position);
                float t = distanciaAlCentro / radioDanyoArea;

                float danyo = Mathf.Lerp(
                    danyoAreaEnOrigen, 
                    danyoAreaEnBorde, 
                    Mathf.Clamp01(t));
                c.GetComponent<IGolpeable>().RecibeDanyo(danyo);
            }
        }
    }

    private bool ColliderEsAfectable(Collider other)
    {
        bool esAfectable = false;
        foreach (string t in tagsAfectados)
        {
            if (other.CompareTag(t))
            {
                esAfectable = true;
            }
            else
            {
                esAfectable = false;
            }
        }

        return esAfectable;
    }


}
