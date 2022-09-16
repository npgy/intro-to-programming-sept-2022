using Banking.Api.Domain;
using Banking.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers;

public class AccountsController : ControllerBase
{
    private readonly AccountManager _accountManager;

    public AccountsController(AccountManager accountManager)
    {
        _accountManager = accountManager;
    }

    // GET /accounts
    [HttpGet("/accounts")]
    public async Task<ActionResult> GetAllAccounts()
    {
        CollectionResponse<AccountSummaryResponse> response = await _accountManager.GetAllAccountsAsync();
        return Ok(response); // return a 200 Ok status code.
    }

    // GET /accounts/{id}
    [HttpGet("/accounts/{id}", Name = "get-account-by-id")]
    public async Task<ActionResult> GetAccountById(string id)
    {
        AccountSummaryResponse? response = await _accountManager.GetAccountByIdAsync(id);

        if(response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }

    [HttpPost("/accounts")]
    public async Task<ActionResult> AddAnAccount([FromBody] AccountCreateRequest request)
    {
        // validate it.
        // if bad, return 400
        // save it to the database
        // return a 201 created status code
        // return a location header with the uri of the brand new thing
        // and give them a copy of what they would get if they did a get request on that location header.
        

        AccountSummaryResponse response = await _accountManager.CreateAccountAsync(request);

        return CreatedAtRoute("get-account-by-id", new { id = response.Id }, response);
    }
}
