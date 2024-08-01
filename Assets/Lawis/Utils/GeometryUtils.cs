using UnityEngine;

namespace Assets.Lawis.Utils
{
    public static class GeometryUtils
    {
        public static Vector3 GetRandomPositionAround(Vector3 center, float radius, Vector3 upVector)
        {
            // Generar un ángulo aleatorio en radianes
            float angle = Random.Range(0f, Mathf.PI * 2);

            // Generar una distancia aleatoria dentro del radio dado
            float distance = Random.Range(0f, radius);

            // Calcular las coordenadas dependiendo de qué componente es constante
            float x = center.x;
            float y = center.y;
            float z = center.z;

            if (upVector.x != 0) // Mantener X constante
            {
                x = upVector.x;
                y = center.y + distance * Mathf.Cos(angle);
                z = center.z + distance * Mathf.Sin(angle);
            }
            else if (upVector.y != 0) // Mantener Y constante
            {
                x = center.x + distance * Mathf.Cos(angle);
                y = upVector.y;
                z = center.z + distance * Mathf.Sin(angle);
            }
            else if (upVector.z != 0) // Mantener Z constante
            {
                x = center.x + distance * Mathf.Cos(angle);
                y = center.y + distance * Mathf.Sin(angle);
                z = upVector.z;
            }

            return new Vector3(x, y, z);
        }

        public static Vector3 GetRandomPositionCircle(Vector3 center, float radius, Vector3 upVector)
        {
            // Generar un ángulo aleatorio en radianes
            float angle = Random.Range(0f, Mathf.PI * 2);

            // Calcular las coordenadas dependiendo de qué componente es constante
            float x = center.x;
            float y = center.y;
            float z = center.z;

            if (upVector.x != 0) // Mantener X constante
            {
                x = upVector.x;
                y = center.y + radius * Mathf.Cos(angle);
                z = center.z + radius * Mathf.Sin(angle);
            }
            else if (upVector.y != 0) // Mantener Y constante
            {
                x = center.x + radius * Mathf.Cos(angle);
                y = upVector.y;
                z = center.z + radius * Mathf.Sin(angle);
            }
            else if (upVector.z != 0) // Mantener Z constante
            {
                x = center.x + radius * Mathf.Cos(angle);
                y = center.y + radius * Mathf.Sin(angle);
                z = upVector.z;
            }

            return new Vector3(x, y, z);
        }
    }
}
