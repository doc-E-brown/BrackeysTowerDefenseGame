using System.Numerics;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Turret : MonoBehaviour
{
    [Header("General")]
    public float range = 15f;
    
    [Header("Use Bullets (default)")]
    public float rotationSpeed = 10f;
    public float fireRate = 1f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;
    
    
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    
    private float _xRotation = 0f;
    private float _zRotation = 90f;
    private Transform _target;
    private float _fireCountDown = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        lineRenderer.enabled = false;
        impactLight.enabled = false;
        impactEffect.Stop();
    }

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float minDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && minDistance <= range)
        {
            _target = nearestEnemy.transform;
            Debug.Log(_target.transform);
        }
        else
        {
            _target = null;
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (_target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactLight.enabled = false;
                    impactEffect.Stop();
                }
            }
            return;
        }
        
        LockOnTarget();

        if (useLaser)
        {
            FireLaser();
        }
        else
        {
            if (_fireCountDown <= 0)
            {
                Shoot();
                _fireCountDown = 1f / fireRate;
            }
            _fireCountDown -= Time.deltaTime;
        }
    }

    void FireLaser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactLight.enabled = true;
            impactEffect.Play();

        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, _target.position);

        Vector3 direction = firePoint.position - _target.position;

        impactEffect.transform.position = _target.position + direction.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(direction);
    }

    void LockOnTarget()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(_xRotation, rotation.y, _zRotation);
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null) 
        {
            bullet.Seek(_target);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, range); 
    }
}
