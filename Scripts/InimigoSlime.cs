using UnityEngine;
using UnityEngine.SceneManagement;

public class InimigoSlime : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public LayerMask barreira;
    public Vector2 alvoTitle;
    public float rotateSpeed = 5f;
	public Rigidbody2D rb2;
    [SerializeField] private Transform transformPlayer01;
    [SerializeField] private Transform transformPlayer02;
    [SerializeField] private Transform transformPlayer03;
    private float distance1;
    private float distance2;
    private float distance3;

	
    private void Start() {
        rb2 = GetComponent<Rigidbody2D>();
        }
    private void Update() {
        if (target == null) {
            PegarAlvo(); // pegar o alvo           
            }
            else {
                VirarParaAlvo();
                AtualizarTitle();
            }
        }

    void FixedUpdate() {
        transform.position = Vector2.MoveTowards(
            transform.position,
            alvoTitle,
            speed * Time.deltaTime
        );
        distance1 = Vector3.Distance(transformPlayer01.position, transform.position);
        distance2 = Vector3.Distance(transformPlayer02.position, transform.position);
        distance3 = Vector3.Distance(transformPlayer03.position, transform.position);
    }
    private void PegarAlvo() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (var playerFound in players)
        {
            if ((distance1 > distance2) && (distance1 > distance3))
            {
                
            }
        }


        
        
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            target = player.transform;
            }
    }
    private void VirarParaAlvo() {
        Vector2 direcaoAlvo = target.position - transform.position;
        float angulo = Mathf.Atan2(direcaoAlvo.y, direcaoAlvo.x) * Mathf.Rad2Deg- 90f;
        Quaternion q = Quaternion.Euler(0, 0, angulo);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotateSpeed * Time.deltaTime);
    }
    private void AtualizarTitle() {
        alvoTitle = new Vector2(
            Mathf.Round(target.position.x),
            Mathf.Round(target.position.y)
        );
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
