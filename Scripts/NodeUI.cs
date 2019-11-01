using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;
    
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition(); //offsets the centre of our node doesnt build directly on top of it
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        
        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide() //reference to canvas to enable and disable it
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //cant call hide as the node will be selected but ui hidden
    }

    public void Sell()
    {
        target.SellTurret();
        target.isUpgraded = false;
        BuildManager.instance.DeselectNode();
    }
}
