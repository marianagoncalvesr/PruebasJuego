using System.Collections.Generic;
using System.Text;

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

    public Stats()
    {
        listPowerUps = new List<PowerUpItem>();
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Diamants {Diamants}");
        sb.AppendLine($"Enemies {Enemies}");
        sb.AppendLine($"LivesRemain {LivesRemain}");
        sb.AppendLine("---------------");
        sb.AppendLine($"PointsDiamants {PointsDiamants}");
        sb.AppendLine($"PointsEnemies {PointsEnemies}");
        sb.AppendLine($"PointsLivesRemain {PointsLivesRemain}");

        return sb.ToString();

    }
    public void AddPowerUp(PowerUpItem item)
    {
        try
        {

            listPowerUps.Add(item);
        }
        catch (System.Exception ex)
        {

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

