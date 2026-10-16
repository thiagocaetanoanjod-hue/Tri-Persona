using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movimentacao_player : MonoBehaviour
{
    public float forcaDashPublic = 10f;

    public BoxCollider2D bc2;

    public Rigidbody2D rb2;

    public AcoesPlayer acoesPlayer;

    private Vector2 direcoesMovimento;

    public float velocidadeMovimento = 5f;

    [SerializeField] private Animator playerAnimation;

    private Camera cam;

    [SerializeField] private AudioClip DashSound;

    [SerializeField] private AudioSource AudioSourcePlayer;

    [SerializeField] private AudioClip NaPonte;

    void Start()
    {
        cam = Camera.main;
    }

    void Awake()
    {
        acoesPlayer = new AcoesPlayer();
        acoesPlayer.player.dash.performed += Dash;
    }

    private void OnEnable()
    {
        acoesPlayer.Enable();
    }

    private void OnDisable()
    {
        acoesPlayer.Disable();
    }

    private void Dash(InputAction.CallbackContext ctx)
    {
        rb2.AddForce(Vector2.up * forcaDashPublic, ForceMode2D.Impulse);
        AudioSourcePlayer.PlayOneShot(DashSound);

    }

    void FixedUpdate()
    {
        direcoesMovimento = acoesPlayer.player.mover.ReadValue<Vector2>();
        transform.Translate(direcoesMovimento * velocidadeMovimento * Time.deltaTime);

        playerAnimation.SetFloat("x", direcoesMovimento.x);
        playerAnimation.SetFloat("y", direcoesMovimento.y);

        if (direcoesMovimento != Vector2.zero)
        {
            playerAnimation.SetInteger("Andando", 1);
            Vector3 novaEscala = transform.localScale;
            novaEscala.x = Mathf.Sign(direcoesMovimento.x) * Mathf.Abs(novaEscala.x);
            transform.localScale = novaEscala;
        }
        else
        {
            playerAnimation.SetInteger("Andando", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ponte"))
        {
            AudioSourcePlayer.clip = NaPonte;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ponte"))
        {
            AudioSourcePlayer.Stop();
        }
    }

    

    public void Morrer()
    {
        playerAnimation.SetInteger("Morto", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerAnimation.SetInteger("Morto", 1);
    }

    void Update()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);

        bool foraDaTela =
            viewportPos.x < 0 || viewportPos.x > 1 ||
            viewportPos.y < 0 || viewportPos.y > 1;

        if (foraDaTela)
        {
            Morrer();
        }
    }
}
