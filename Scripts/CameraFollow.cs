using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform transformPlayer01;
    [SerializeField] private Transform transformPlayer02;
    [SerializeField] private Transform transformPlayer03;
    [SerializeField] private float velocidadeCamera = 5f;


    void LateUpdate()
    {
        Vector2 centro = CalcularCentro();

        Vector3 destino = new Vector3(centro.x, centro.y, transform.position.z);

        transform.position = Vector3.Lerp(
            transform.position,
            destino,
            velocidadeCamera * Time.deltaTime
        );
    }

    Vector2 CalcularCentro()
    {
        return (transformPlayer01.position +
                transformPlayer02.position +
                transformPlayer03.position) / 3f;
    }
}
