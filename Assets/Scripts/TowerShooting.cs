using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HietakissaUtils.Timer;

public class TowerShooting : MonoBehaviour
{
    //public GameObject[] enemies;

    public Timer shoot;

    Collider[] colliderArray = new Collider[10];

    [SerializeField] GameObject linecastStart;
    [SerializeField] GameObject projectile;

    [SerializeField] float shootTime;
    [SerializeField] float projectileSpeed;

    [SerializeField] LayerMask enemy;
    [SerializeField] LayerMask ground;

    void Awake()
    {
        Timer shoot = new Timer(shootTime, gameObject);

        shoot.OnCompleted += Shoot;
    }

    private void Start()
    {
        
    }

    void Shoot()
    {
        Physics.OverlapSphereNonAlloc(transform.position, 75f, colliderArray, enemy);

        for (int i = 0; i < colliderArray.Length; i++)
        {
            if (colliderArray[i] != null)
            {
                print($"{colliderArray[i]} had collider");


            }
            else if (colliderArray[i] == null)
            {
                print($"{colliderArray[i]} had no collider");

                return;
            }
            

            if (Physics.Linecast(linecastStart.transform.position, colliderArray[i].transform.position, out RaycastHit hit, ground))
            {
                print("didn't hit ground");

                if (hit.collider != colliderArray[i])
                {
                    print("hit collider, but it wasn't an enemys collider");
                    continue;
                }

                Projectile projectileIns = Instantiate(projectile, linecastStart.transform.position, Quaternion.identity).GetComponent<Projectile>();

                projectileIns.TakeDir((colliderArray[i].transform.position - linecastStart.transform.position).normalized * projectileSpeed);
                print("Shot the projectile towards the enemy");

                return;
            }
        }
    }

    private void Update()
    {
        //print(colliderArray[0]);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 75f);

        if (colliderArray[0] == null) return;
        Gizmos.color = Color.red;

        if (colliderArray.Length != 0) Gizmos.DrawLine(linecastStart.transform.position, colliderArray[0].transform.position);
    }
}
