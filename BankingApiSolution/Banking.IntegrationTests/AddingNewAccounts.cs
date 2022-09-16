using apiModels = Banking.Api.Models;
using System.Text.RegularExpressions;


namespace Banking.IntegrationTests;
public class AddingNewAccounts
{
    [Fact]
    public async Task AddingANewAccount()
    {
        var newAccount = new apiModels.AccountCreateRequest { Name = "Sue Jones" };

        await using var host = await AlbaHost.For<global::Program>(config => { });

        var result = await host.Scenario(api =>
        {
            api.Post.Json(newAccount).ToUrl("/accounts");
            api.StatusCodeShouldBe(201);
            api.ContentTypeShouldBe("application/json; charset=utf-8");
            api.Header("Location")
            .SingleValueShouldMatch(new Regex(@"^http://localhost/accounts/.*$"));
        });

        var response = result.ReadAsJson<apiModels.AccountSummaryResponse>();

        Assert.Equal(newAccount.Name, response?.Name);
        Assert.NotNull(response?.Id);
        var newId = response.Id;

        var balanceResult = await host.Scenario(api =>
        {
            api.Get.Url($"/accounts/{newId}/balance");
            api.StatusCodeShouldBeOk();
            api.ContentTypeShouldBe("application/json; charset=utf-8");
        });

        var balanceResponse = balanceResult.ReadAsJson<apiModels.AccountBalanceResponse>();

        Assert.Equal(5000M, balanceResponse?.Balance);


        var depositToPost = new apiModels.AccountTransactionRequest { Amount = 100M };

        var depositResponse = await host.Scenario(api =>
        {
            api.Post.Json(depositToPost).ToUrl($"/accounts/{newId}/deposits");
            api.StatusCodeShouldBe(201);
            api.ContentTypeShouldBe("application/json; charset=utf-8");
        });

        var transactionResult = depositResponse.ReadAsJson<apiModels.AccountTransactionResponse>();
        Assert.Equal(DateTime.Now, transactionResult?.PostedAt);
    }
}
