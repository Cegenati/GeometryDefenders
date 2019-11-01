using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake() //Every time we start a game we only make one build manager
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in Scene!");
        }
        instance = this; //Put this build manage into this instance variable whcih can be accessed everywhere
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    //Gives the turret to build we chose to build manager
    private TurretBlueprint turretToBuild;
    private Node selectNode;

    public NodeUI nodeUI;

    public bool CanBuild { get {return turretToBuild!=null;}} //Property can only get something equivalent of writing a small function tha checks if the turret is equal to null
    public bool HasMoney {get {return PlayerStats.Money >= turretToBuild.cost;}}

    public void SelectNode (Node node)
    {
        if (selectNode == node)
        {
            DeselectNode();
            return;
        }
        
        selectNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }


}
