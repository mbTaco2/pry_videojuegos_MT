using UnityEngine;
using UnityEngine.UIElements;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controlGolpe;
    [SerializeField] private float rdGolpe;
    [SerializeField] private int danoGolpe;
    [SerializeField] private float tmpAtak;
    [SerializeField] private float tmpSigAtak;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (tmpSigAtak > 0) { 
            tmpSigAtak -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q) && tmpSigAtak <=0) {
        
            Golpe();
            tmpSigAtak = tmpAtak;
        }
    }
    private void Golpe()
    {
        animator.SetTrigger("golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controlGolpe.position, rdGolpe);
        foreach(Collider2D colision in objetos)
        {
            if (colision.CompareTag("Jefe"))
            {
                colision.GetComponent<VidaJefe>().TomarDaño(danoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controlGolpe.position, rdGolpe);
    }
}
