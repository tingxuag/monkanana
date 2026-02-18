using UnityEngine;

public class bananaMove : MonoBehaviour
{
    public float bananaSpeed;
    //public GameObject bananaParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.parent = bananaParent.transform;
        bananaSpeed = transform.parent.gameObject.GetComponent<parentScript>().fallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*bananaSpeed*Time.deltaTime, Space.World);

        if(transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}
