using Static;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test] // [Test] nous indique que la méthode est un 'test unitaire'
    public void Test1()
    {
        // Assert.AreEqual(expected, actual) permet de vérifier que les deux valeurs 'expected' et 'actual' sont identiques.
        Assert.AreEqual("89.04.03-341.82", "89040334182".PrettyPrintBelgianNationalNumber());
    }
}