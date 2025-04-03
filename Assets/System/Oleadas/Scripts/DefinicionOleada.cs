using UnityEngine;

[CreateAssetMenu]
public class DefinicionOleada : ScriptableObject
{
    [System.Serializable]
    public class BloqueEnemigos
    {
        public GameObject tipoEnemigos;
        public int cantidad;
        public float enemigosPorSegundo;
    }
    public BloqueEnemigos[] bloques;
}
