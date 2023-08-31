using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;




public enum fishdd
{
    little,
    big
}
public class Boid : MonoBehaviour
{
    public GameObject dayu;

    float dayuleida;


    public float  eatcount;



    public fishdd fs;



    public static Boid boid;


    public GameObject excreta;
    public float excretatime=17;
   public  bool isexcre;




    public float hungryflot;
    public float maxhungry;
    public float minhungry; //hungry

   public  bool ishungry;
    public bool truefood;
    public bool truefish;

    public seagrass targetScript;
    public GameObject[] seagrass;
    public  GameObject targetObject;  // Small fish randomly target objects

    public Boid targetbigScript;
    public GameObject[] seagrassbig;
    public  GameObject targebigtObject; //Big fish random target


    BoidSettings settings;

    // State
    [HideInInspector]
    public Vector3 position; // current position

    [HideInInspector]
    public Vector3 forward; // current forward

    public Vector3 velocity; // current speed

    // To update:
    Vector3 acceleration; // Current acceleration
    [HideInInspector]
    public Vector3 avgFlockHeading; // Mean orientation of fish school
    [HideInInspector]
    public Vector3 avgAvoidanceHeading; // Average direction of avoidance
    [HideInInspector]
    public Vector3 centreOfFlockmates; // Central position of fish school
    [HideInInspector]
    public int numPerceivedFlockmates; // The perceived number of fish members

    // Cached

    Transform cachedTransform; // Cached Transform component
    Transform target; //target location


    private void Start()
    {

        dayuleida = 2f;
   

            isexcre = false;
            remakehungry();
            ishungry = false;

            faxianhaicao();
            faxianxiaoyu();




    }

    public void remakehungry()
    {
        hungryflot = Random.Range(maxhungry, minhungry);
    }// Reset hunger

    public void faxianxiaoyu()
    {

        seagrassbig = FindObjectsOfType<GameObject>()
            .Where(obj => obj.GetComponent(targetbigScript.GetType()) != null && obj.GetComponent<Boid>().fs == fishdd.little)
                         .ToArray();


    }//Traverse the fish

    public void faxianhaicao()
    {

        seagrass = FindObjectsOfType<GameObject>()
             .Where(obj => obj.GetComponent(targetScript.GetType()) != null)
             .ToArray();


    }// Traverse the seagrass

    private void Update()
    {
        if (fs == fishdd.big)
        {
            dayuleida -= Time.deltaTime;
            if (dayuleida >= 2)
            {
                faxianxiaoyu();
                dayuleida = 0;
            }
        }


        if (eatcount > 5)
        {
            if (fs == fishdd.little)
            {
                Instantiate(dayu, transform.position, transform.rotation);
                Destroy(gameObject);
            }
          
        }

        if (isexcre)
        {
            excretaON();
        }
        hungryflot -= Time.deltaTime;
        if (hungryflot<=(Random .Range(maxhungry, minhungry) / 2))
        {
            ishungry = true;
            faxianxiaoyu();
            faxianhaicao();
         
        }
        else
        {
            ishungry = false;
        }
      
        if (hungryflot <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        boid = this;

       
        cachedTransform = transform;
    }

    public void Initialize(BoidSettings settings, Transform target)
    {
        this.target = target;
        this.settings = settings;

        position = cachedTransform.position;
        forward = cachedTransform.forward;

        float startSpeed = (settings.minSpeed + settings.maxSpeed) / 2;
        velocity = transform.forward * startSpeed;
    }

 

    void running()
    {
       
        Vector3 acceleration = Vector3.zero;

        if (target != null)
        {
            Vector3 offsetToTarget = (target.position - position);
            acceleration = SteerTowards(offsetToTarget) * settings.targetWeight; // Apply acceleration to the target position
        }

        if (numPerceivedFlockmates != 0)
        {
            centreOfFlockmates /= numPerceivedFlockmates;

            Vector3 offsetToFlockmatesCentre = (centreOfFlockmates - position);

            var alignmentForce = SteerTowards(avgFlockHeading) * settings.alignWeight; // Congruence in a school of fish
            var cohesionForce = SteerTowards(offsetToFlockmatesCentre) * settings.cohesionWeight; // Cohesion in a school of fish
            var seperationForce = SteerTowards(avgAvoidanceHeading) * settings.seperateWeight; //The force of separation in a school of fish

            acceleration += alignmentForce;
            acceleration += cohesionForce;
            acceleration += seperationForce;
        }

        if (IsHeadingForCollision())
        {
            Vector3 collisionAvoidDir = ObstacleRays();
            Vector3 collisionAvoidForce = SteerTowards(collisionAvoidDir) * settings.avoidCollisionWeight; // The force of avoiding obstacles
            acceleration += collisionAvoidForce;
        }

        velocity += acceleration * Time.deltaTime;
        float speed = velocity.magnitude;
        Vector3 dir = velocity / speed;
        speed = Mathf.Clamp(speed, settings.minSpeed, settings.maxSpeed);
        velocity = dir * speed;

        cachedTransform.position += velocity * Time.deltaTime;
        cachedTransform.forward = dir;
        position = cachedTransform.position;
        forward = dir;
    }

    public void UpdateBoid()
    {
        if (ishungry)
        {
            if (fs == fishdd.little)
            {
                if (truefood)
                {
                    hungryyyy();
                }
                else
                {
                    running();
                }
            }

            if (fs == fishdd.big)
            {
              
                if (truefish)
                {

                    hurrybigg();
                }
                else
                {

                    running();
                }
            }
            if 
                (fs == fishdd.big)
            {
                faxianxiaoyu();            }
          
        }
        else
        {
            running();
        }


       
      if (fs == fishdd.little)
        {
            if (targetObject==null)
            {
                faxianhaicao();
                chosefood();
               
            }
        }
        if (fs == fishdd.big)
        {
            if (targetObject == null)
            {
                faxianxiaoyu();
                chosefish();
               
               
            }
        }

    }

 
     private void chosefish()
    {
        if (seagrassbig.Length > 0)
        {
            truefish = true;
            int randomIndex = Random.Range(0, seagrassbig.Length);
            targebigtObject = seagrassbig[randomIndex];
        }
        else
        {
            truefish = false;
        }
    }
    private void chosefood()
    {
        if (seagrass.Length > 0)
        {

            int randomIndex = Random.Range(0, seagrass.Length);
            targetObject = seagrass[randomIndex];
        }
        if (targetObject != null)
        {
            truefood = true;
        }
        else
        {
            truefood = false;
        }
    }

    private void hurrybigg()
    {
       
           if (targebigtObject==null)
        {
            chosefish();
        }else
        {
            Vector3 targetDirection = targebigtObject.transform.position - transform.position;
            targetDirection.Normalize();


            transform.position += targetDirection * (7f) * Time.deltaTime;

            // Orient the fish towards the moving target
            transform.LookAt(targebigtObject.transform);

            if (Vector3.Distance(gameObject.transform.position, targebigtObject.transform.position) <= 2f)
            {
                Destroy(targebigtObject.gameObject);
                faxianxiaoyu();
                remakehungry();
                ishungry = false;
            }
        }
          

      
     
    }
    private void hungryyyy()
    {

        if (targetObject != null)
        {
            truefood = true;
            Vector3 targetDirection = targetObject.transform.position - transform.position;
            targetDirection.Normalize();


            transform.position += targetDirection * (5f) * Time.deltaTime;

            // Orient the fish towards the moving target
            transform.LookAt(targetObject.transform);
        }
        else
        {
            truefood = false;
        }

      
        
      
    }

    bool IsHeadingForCollision()
    {
        RaycastHit hit;
        if (Physics.SphereCast(position, settings.boundsRadius, forward, out hit, settings.collisionAvoidDst, settings.obstacleMask))
        {
            return true; // Whether to move towards the collider
        }
        else { }
        return false;
    }

    Vector3 ObstacleRays()
    {
        Vector3[] rayDirections = BoidHelper.directions;

        for (int i = 0; i < rayDirections.Length; i++)
        {
            Vector3 dir = cachedTransform.TransformDirection(rayDirections[i]);
            Ray ray = new Ray(position, dir);
            if (!Physics.SphereCast(ray, settings.boundsRadius, settings.collisionAvoidDst, settings.obstacleMask))
            {
                return dir;
            }
        }

        return forward;
    }

    Vector3 SteerTowards(Vector3 vector)
    {
        Vector3 v = vector.normalized * settings.maxSpeed - velocity;
        return Vector3.ClampMagnitude(v, settings.maxSteerForce); // Limit the vector according to the maximum steering force
    }


     public void  excretaON()
    {
        excretatime -= Time.deltaTime;
        if (excretatime <= 0)
        {
            Instantiate(excreta, gameObject.transform.position, Quaternion.identity);
            isexcre = false;
            excretatime = 17;
            
        }
       
    }

}