using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seagrass : MonoBehaviour
{
    public float EATCOUNT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EATCOUNT <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other .tag == "fash")
        {
            if (other .GetComponent<Boid>().fs == fishdd.little)
            {
                other.GetComponent<Boid>().isexcre = true;
                other.GetComponent<Boid>().eatcount +=1;
                other.GetComponent<Boid>().remakehungry();
                Boid.boid.faxianhaicao();
                EATCOUNT -= 1;

            }
           
        }
        if (other.tag == "excreta")
        {
            EATCOUNT += 5;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
      
        if (other.tag == "fash")

        {
            if (other.GetComponent<Boid>().fs == fishdd.little)
            {

                other.GetComponent<Boid>().remakehungry();
                Boid.boid.faxianhaicao();

            }

            if (other.tag == "excreta")
            {
                EATCOUNT += 5;
                Destroy(other.gameObject);
            }
        }
    }
}
