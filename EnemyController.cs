using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    private bool isAware = false;
    private bool isDetecting = false;
    private float loseTimer = 0;
    private NavMeshAgent myAgent;
    public float enemyHealth = 100f;
    public float fov = 120f;
    public float lookRadius = 10f;
    public float losePlayer = 5f;
    public float xPos, zPos;
    public Transform target;
    public Animator myAnim;
    public bool attacking = false;
    public bool isClown;
    public ParticleSystem pop;
    public GameObject obj, gameManager;
    public AudioSource src;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myAgent = GetComponent<NavMeshAgent>(); 
        myAnim = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (isAware)
        {
            FaceTarget();
            myAnim.SetBool("isRunning", true);
            myAgent.speed = 4.5f;
            myAgent.SetDestination(target.position); 
            if (distance <= myAgent.stoppingDistance + 0.5f)
            {
                myAnim.SetBool("isAttack", true);
                attacking = true;
            }
            else
            {
                myAnim.SetBool("isAttack", false);
                attacking = false;
            }
            if(!isDetecting)
            {
                loseTimer += Time.deltaTime;
                if(loseTimer >= losePlayer)
                {
                    isAware = false;
                    loseTimer = 0;
                }
            }
        }
        else
        {
            src.Stop();
            myAnim.SetBool("isRunning", false);
            myAgent.speed = 0;
        }
        SearchForPlayer();
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(target.position)) < fov / 2f)
        {
            if (Vector3.Distance(target.position, transform.position) < lookRadius)
            {
                RaycastHit hit;
                if(Physics.Linecast(transform.position, target.position, out hit, -1))
                {
                    if(hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                    else
                    {
                        isDetecting = false;
                    }
                } else
                {
                    isDetecting = false;
                }
            } else
            {
                isDetecting = false;
            }
        } else
        {
            isDetecting = false;
        }
    }
    public void OnAware()
    {
        src.Play();
        isAware = true;
        isDetecting = true;
        loseTimer = 0;
    }
    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;
        if(enemyHealth == 80 && isClown)
        {
            pop.Play();
            obj.GetComponent<EnemyPop>().Dead();
        }
        if (enemyHealth <= 0)
        {
            StartCoroutine(EnemyDead());
        }
    }

    IEnumerator EnemyDead()
    {
        myAgent.updatePosition = false;
        myAnim.SetBool("isDied", true);
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Metal"))
        {
            xPos = Random.Range(-77, 15);
            zPos = Random.Range(-35, 60);
            Instantiate(myAgent, new Vector3(xPos, 4, zPos), Quaternion.identity);
            Debug.Log("Overlapped");
            Destroy(gameObject);
        }

    }
   
}
