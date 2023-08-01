using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Application.Common.Dtos.Customers;
using Project1.Application.Features.Customers.Commands.CustomerCreate;
using Project1.Application.Features.Customers.Commands.CustomerDelete;
using Project1.Application.Features.Customers.Commands.CustomerUpdate;
using Project1.Application.Features.Customers.Queries;

namespace Api.Controllers
{

	public class CustomerController : ApiControllerBase
	{

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result = await Mediator.Send(new CustomerGetAllQuery());
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Post(CustomerCreateViewModel customerCreateViewModel)
		{
			if (customerCreateViewModel == null)
			{
				return BadRequest();
			}

			var result = await Mediator.Send(new CustomerCreateCommand { CustomerViewModel = customerCreateViewModel });
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, CustomerUpdateViewModel customerUpdateViewModel)
		{
			if (id != customerUpdateViewModel.Id)
			{
				return BadRequest();
			}
			if (customerUpdateViewModel == null)
			{
				return BadRequest();
			}
			var result = await Mediator.Send(new CustomerUpdateCommand { CustomerViewModel = customerUpdateViewModel });
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}
			var result = await Mediator.Send(new CustomerDeleteCommand { Id = id });

			return Ok(result);
		}
	}
}
