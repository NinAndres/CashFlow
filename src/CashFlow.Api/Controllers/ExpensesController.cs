using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : CashFlowBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterExpenseJson), StatusCodes.Status201Created)]
        public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
        {
            var response = new RegisterExpenseUseCase().Execute(request);

            return Created(string.Empty, response);
        }
    }
}