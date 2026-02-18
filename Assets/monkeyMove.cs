using UnityEngine;

public class monkeyMove : MonoBehaviour
{
    public float monkeySpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monkeySpeed = transform.parent.gameObject.GetComponent<parentScript>().fallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*monkeySpeed*Time.deltaTime, Space.World);

        if(transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
