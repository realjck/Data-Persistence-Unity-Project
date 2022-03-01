using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsBackground : MonoBehaviour
{
    [SerializeField] private float speed;
    private float height;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        height = GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if ((transform.position.y - startY) > height /2){
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }
}
