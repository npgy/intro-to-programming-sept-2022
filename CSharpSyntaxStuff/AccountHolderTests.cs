namespace CSharpSyntaxStuff;
public class AccountHolderTests
{
    [Fact]
    public void AccountHolderStuff()
    {
		AccountHolder ah1;
		try
		{
			ah1 = AccountHolder.Create("joe", "3465-ff");
		}
		catch (ArgumentException)
		{

			throw;
		}

		Assert.Equal("JOE", ah1.Name);

		var newAh = AccountHolder.ChangeName(ah1, "bill");

		Assert.Equal("BILL", newAh.Name);

    }
}
