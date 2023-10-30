using UnityEngine;
using UnityEngine.Serialization;

public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    
    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;

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
