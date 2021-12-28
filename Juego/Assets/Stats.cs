using System.Collections.Generic;

public class Stats
{

    private List<PowerUpItem> listPowerUps;
    public int Diamants { get; set; }
    public int Enemies { get; set; }
    public int LivesRemain { get; set; }


    public int PointsDiamants { get => Diamants * 10; }
    public int PointsEnemies { get => Enemies * 15; }
    public int PointsLivesRemain { get => LivesRemain * 10; }
    public List<PowerUpItem> ListPowerUps { get => listPowerUps; }


    public void AddPowerUp(PowerUpItem item)
    {
        try
        {

            listPowerUps.Add(item);
        }
        catch (System.Exception ex)
        {
;
        }
    }


    public void UsePowerUp(string name)
    {
        PowerUpItem pw = listPowerUps.Find((x) => x.Name == name);
        if (pw != null)
        {
            pw.Used = true;
        }

    }


    public int CalculatePoints()
    {
        return PointsDiamants + PointsEnemies + PointsLivesRemain;
    }

}

public enum EPowerUpType
{
    Shield = 5,
    Health = 10,
    Bonus = 15
}

