using UnityEngine;

public class Jefe_CaminarBehaviour : StateMachineBehaviour
{
    private Jefe jefe;
    private Rigidbody2D rb2D;
    [SerializeField] private float velMov;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe = animator.GetComponent<Jefe>();
        rb2D = jefe.rb2D;

        jefe.MirarJugador();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Calcular la dirección hacia el jugador
        Vector2 direccion = (jefe.jugador.position - jefe.transform.position).normalized;

        // Mover al jefe en la dirección del jugador solo en el eje X
        rb2D.linearVelocity = new Vector2(direccion.x * velMov, rb2D.linearVelocity.y);

        // Asegurarse de que el jefe mire al jugador en cada frame
        jefe.MirarJugador();
        //rb2D.linearVelocity = new Vector2(-velMov, rb2D.linearVelocity.y) * animator.transform.right;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2D.linearVelocity = new Vector2(0,rb2D.linearVelocity.y);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
