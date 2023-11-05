using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance;

    public GameObject buildEffect;
    public NodeUI nodeUI;
    
    private TurretBlueprint _turretToBuild;
    private Node _selectedNode;
    
    public bool CanBuild => _turretToBuild != null;
    public bool CanAfford => PlayerStats.Money > _turretToBuild.cost;

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
        _selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectNode(Node node)
    {

        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }
        _selectedNode = node;
        _turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        nodeUI.Hide();
        _selectedNode = null;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }
        GameObject turret = Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.setTurret(turret);


        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        PlayerStats.Money -= _turretToBuild.cost;
        Debug.Log($"Player money remaining: {PlayerStats.Money}");
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple build managers in scene");
            return;
        }
        Instance = this;
    }
}
