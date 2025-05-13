using UnityEngine;

[CreateAssetMenu(fileName = "DefinicionOleada", menuName = "Scriptable Objects/DefinicionOleada")]
public class DefinicionOleada : ScriptableObject
{
    [System.Serializable]
    public class BloqueEnemigos
    {
        public Enemigo tipoEnemigos;
        public int cantidad;
        public float enemigosPorSegundo;
    }

    public BloqueEnemigos[] bloques;
}
