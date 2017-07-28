using UnityEngine;
using System.Collections;

public class TowerButton : MonoBehaviour {

    public SetTower setTowerScript;

    public void TowerIncome()
    {
        this.setTowerScript.Selected = 0;
    }

    public void TowerShoot()
    {
        this.setTowerScript.Selected = 1;

    }
    public void TowerExpensive()
    {
        this.setTowerScript.Selected = 2;
    }
    public void TowerProtector()
    {
        this.setTowerScript.Selected = 3;
    }
    public void SpikeTraps()
    {
        this.setTowerScript.Selected = 4;
    }
    public void EplosiveTraps()
    {
        this.setTowerScript.Selected = 5;
    }
}
