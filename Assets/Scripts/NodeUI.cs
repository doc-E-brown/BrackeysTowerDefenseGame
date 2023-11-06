using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    private Node _target;

    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI saleCost;
    public Button upgradeButton;

    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = _target.GetBuildPosition();
        
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.currentTurret.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "-";
            upgradeButton.interactable = false;
        }

        saleCost.text = "$" + target.currentTurret.SaleCost();
        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
        
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildManager.Instance.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        BuildManager.Instance.DeselectNode();
    }


    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

}
