namespace stupidCostumes;

class Program
{
    static void Main(string[] args)
    {
        List<Costume> myCostumes = new List<Costume>();
        Costume detective = new Costume();
        detective._headwear = "fedora";
        detective._upperGarment = "plaid jacket";
        detective._lowerGarment = "detective pants";
        detective._footwear = "boots";
        detective._accessories = "magnifying class";
        myCostumes.Add(detective);

        foreach (Costume costume in myCostumes)
        {
            costume.Output();
        }
    }
}
