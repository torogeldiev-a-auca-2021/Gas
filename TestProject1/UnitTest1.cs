using System.Linq;

namespace ConsoleApp4;


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Gase gase = new Ozone(0.6);
            var result = gase.Exist();
            Assert.IsTrue(result);
        }

    [TestMethod]
    public void TestMethod2()
    {
        Gase gase = new Carbon(1.0);
        gase.ModifyThickness(0.5);
        IAtmo atmo = new Thunderstrom();
        Assert.IsTrue(gase.thickness == 0.5);
    }

    [TestMethod]
    public void TestMethod3()
    {
        Gase gase = new Oxygen(1.0);

        var atmo = new Thunderstrom();

        var result = gase.Traverse(atmo);
        Assert.IsTrue(result.Type() != gase.Type());
    }

    [TestMethod]
    public void TestMethod4()
    {
        Gase gase = new Ozone(1.0);
        Gase g = new Oxygen(1.0);
        var atmo = new Other();

        var result = gase.Traverse(atmo);
        Assert.IsTrue(result.Type() == g.Type());
    }

    [TestMethod]
    public void TestMethod5()
    {
        Gase gase = new Ozone(1.0);
        var atmo = new Other();

        var result = gase.Traverse(atmo);
        Assert.IsTrue(!result.Exist());
    }

    [TestMethod]
    public void TestMethod6()
    {
        Gase gase = new Oxygen(4);
        var atmo = new Thunderstrom();

        Gase gas = new Ozone(1);

        List<Gase>g = new List<Gase>();
        g.Add(gase);
        Program.Transform(g, atmo);
        Assert.IsTrue(g[0].Type() == gas.Type() && g[1].Type() == gase.Type());
        
        
    }
}