
using System.Collections;

namespace CSharpSyntaxStuff;

public class CreatingInstancesOfTypes
{
    [Fact]
    public void DeterminingType()
    {
        int x = 12;
        string myName = "Jeff";
        char middleInitial = 'M';
    }

    [Fact]
    public void ImplicitVariableDeclaration()
    {
        var x = 12;

        Assert.Equal(12, x);

        var bob = new Employee();

        var myPay = new PayCheck();

        var manager = new Manager();

        manager.SaveThis(bob);
        manager.SaveThis(myPay);
        manager.SaveThis(42);
    }

    [Fact]
    public void OldSchoolCollections()
    {
        var favoriteNumbers = new ArrayList();
        favoriteNumbers.Add(9);
        favoriteNumbers.Add(42);
        favoriteNumbers.Add(20);

        Assert.Equal(9, favoriteNumbers[0]);

        favoriteNumbers.Add("Pizza");

        // favoriteNumbers[0] = "Three";
        var sumOfFirstTwo = ((int)favoriteNumbers[0]) + ((int)favoriteNumbers[1]);

        Assert.Equal(51, sumOfFirstTwo);
    }

    [Fact]
    public void NewSchoolCollections()
    {
        var favoriteNumbers = new List<int>();

        favoriteNumbers.Add(9);
        favoriteNumbers.Add(42);
        favoriteNumbers.Add(20);

        var sumOfFirstTwo = favoriteNumbers[0] + favoriteNumbers[1];

        Assert.Equal(51, sumOfFirstTwo);
    }
}

public class Employee { }
public struct PayCheck { }

public class Manager
{
    public void SaveThis(Object o)
    {

    }
}