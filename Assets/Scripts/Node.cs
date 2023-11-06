using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color cantAffordColour;
    public Vector3 positionOffset;

    private Renderer _rend;
    private Color _startColor;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint currentTurret;
    [HideInInspector]
    public bool isUpgraded = false;
    
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

    private void BuildTurret(TurretBlueprint turretToBuild)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        currentTurret = turretToBuild;
        
        GameObject newTurret = Instantiate(turretToBuild.prefab, GetBuildPosition(), Quaternion.identity);
        setTurret(newTurret);

        GameObject effect = Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        PlayerStats.Money -= turretToBuild.cost;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < currentTurret.cost)
        {
            Debug.Log("Not enough money to upgrade");
            return;
        }
        
        // Remove the previous turret
        Destroy(turret);
        
        GameObject newTurret = Instantiate(currentTurret.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        setTurret(newTurret);

        GameObject effect = Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        PlayerStats.Money -= currentTurret.cost;

        isUpgraded = true;

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
        BuildTurret(_buildManager.GetTurretToBuild());
    }

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
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
