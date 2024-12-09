using UnityEngine;

public class Seguir : MonoBehaviour
{
    public Transform Jot;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position, new Vector3(Jot.position.x,0f,-5f), 10f * Time.deltaTime);
    }
}
