using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;
    
    private TurretBlueprint _turretToBuild;
    
    public bool CanBuild => _turretToBuild != null;
    public bool CanAfford => PlayerStats.Money > _turretToBuild.cost;

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;

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
