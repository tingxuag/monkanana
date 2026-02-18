using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject bananaPrefab;
    public GameObject monkeyPrefab;
    public GameObject bananaParent;
    public GameObject monkeyParent;
    public int bananaLine;

    public float minTime;
    public float maxTime;
    private float pastTime;
    public bool gameState = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(bananaPrefab, transform.position, transform.rotation, bananaParent.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState){
        pastTime += Time.deltaTime;
        if(pastTime >= minTime && pastTime < maxTime)
        {
            pastTime = 0;
            float ran = UnityEngine.Random.Range(0,5);
            if(ran > 0)
            {
                Spawnit();
                //Instantiate(bananaPrefab, transform.position, transform.rotation, bananaParent.transform);
                //pastTime = 0;
            }
        }
        else if(pastTime >= maxTime)
        {
            //Instantiate(bananaPrefab, transform.position, transform.rotation, bananaParent.transform);
            Spawnit();
            pastTime = 0;
        }
        }
        
    }

    private void Spawnit()
    {
        float ran = UnityEngine.Random.Range(0,5);
        if(ran >= bananaLine)
        {
            Instantiate(bananaPrefab, transform.position, transform.rotation, bananaParent.transform);
        }
        else
        {
            Instantiate(monkeyPrefab, transform.position, transform.rotation, monkeyParent.transform);
        }
    }
}
