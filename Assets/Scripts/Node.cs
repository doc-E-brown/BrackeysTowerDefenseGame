using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color cantAffordColour;
    public Vector3 positionOffset;

    private Renderer _rend;
    private Color _startColor;
    [Header("Optional")]
    public GameObject turret;
    
    private BuildManager _buildManager;
    
    private void OnMouseEnter()
    {

        if (!_buildManager.CanBuild)
        {
            return;
        }

        if (!_buildManager.CanAfford)
        {
            _rend.material.color = cantAffordColour;
            return;
        }
 
        _rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
       
        if (turret != null)
        {
            _buildManager.SelectNode(this);
            return;
        }
        
        if (!_buildManager.CanBuild)
        {
            return;
        }
     
        
        // Build a turret
        _buildManager.BuildTurretOn(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void setTurret(GameObject _turret)
    {
        turret = _turret;

    }
}
