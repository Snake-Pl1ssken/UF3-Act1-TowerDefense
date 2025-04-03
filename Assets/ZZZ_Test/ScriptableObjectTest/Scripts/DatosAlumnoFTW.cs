using UnityEngine;

[CreateAssetMenu(fileName = "DatosAlumnoFTW", menuName = "Scriptable Objects/DatosAlumnoFTW")]
public class DatosAlumnoFTW : ScriptableObject
{
    public string nombre = "<Nombre>";
    public string primerApellido = "<Primer Apellido>";
    public string segundoApellido = "<Segundo Apellido>";

    [Range(0f, 10f)] public float notaRedes = 10f;
    [Range(0f, 10f)] public float notaProyectos = 10f;
    [Range(0f, 10f)] public float notaMoviles = 10f;

    void DebugAlumno()
    {
            Debug.Log(
        $"Nombre: {nombre} \n" +
        $"Primer Apellido: {primerApellido} \n" +
        $"Segundo Apellido: {segundoApellido}");
    }

}
