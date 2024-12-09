using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private float parallaxMultiple;
    private Transform camaraTransform;


    private Vector3 pvCameraPs;
    private float spriteWidth, startPosition;
    public bool GameOver=false;
    public bool start = false;  
    private void Start()
    {
        camaraTransform = Camera.main.transform;
        pvCameraPs = camaraTransform.position;
        spriteWidth= GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;

    }

    private void LateUpdate()
    {
            float deltaX = (camaraTransform.position.x - pvCameraPs.x) * parallaxMultiple;
            float mvAmount = camaraTransform.position.x * (1 - parallaxMultiple);
            transform.Translate(new Vector3(deltaX, 0, 0));
            pvCameraPs = camaraTransform.position;

            if (mvAmount > startPosition + spriteWidth)
            {
                transform.Translate(new Vector3(spriteWidth, 0, 0));
                startPosition += spriteWidth;
            }
            else if (mvAmount < startPosition - spriteWidth)
            {
                transform.Translate(new Vector3(-spriteWidth, 0, 0));
                startPosition -= spriteWidth;
            }
    }
}
