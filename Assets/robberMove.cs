using UnityEngine;

public class robberMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*10*Time.deltaTime);
        if(transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
    }
}
