using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;

    private Renderer _rend;
    private Color startColor;
    private GameObject turret;
    private BuildManager _buildManager;
    
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (_buildManager.getTurretToBuild() == null)
        {
            return;
        }
 
        _rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = startColor;
    }

    private void OnMouseDown()
    {

        if (_buildManager.getTurretToBuild() == null)
        {
            return;
        }
        
        if (turret != null)
        {
            Debug.Log("Cannot build here!");
            return;
        }
        
        // Build a turret
        GameObject turretToBuild = BuildManager.Instance.getTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
