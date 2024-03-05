using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.API.Test.ResponseParser
{
	public class ResponseParser
	{
		public static Task<T> GetObjectFromOkResponse<T>(ActionResult<T> response)
		{
			var objectResult = response.Result.Should().BeOfType<OkObjectResult>().Subject;
			return Task.FromResult(objectResult.Value.Should().BeAssignableTo<T>().Subject);
		}

		public static Task<List<T>> GetListObjectFromOkResponse<T>(ActionResult<List<T>> response)
		{
			var objectResult = response.Result.Should().BeOfType<OkObjectResult>().Subject;
			return Task.FromResult(objectResult.Value.As<List<T>>());
		}

		public static Task<CreateResponse<T>> GetObjectFromCreatedResponse<T>(ActionResult<T> response)
		{
			var result = response.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
			return Task.FromResult(
				new CreateResponse<T>
				{
					ActionName = result.ActionName!,
					Value = result.Value.Should().BeAssignableTo<T>().Subject,
				});
		}

		public static Task<string> GetErrorMessageFromBadRequestResponse<T>(ActionResult<T> response)
		{
			var objectResult = response.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
			return Task.FromResult((string)objectResult.Value!);
		}
		public static Task<string> GetErrorMessageFromConflictResponse<T>(ActionResult<T> response)
		{
			var objectResult = response.Result.Should().BeOfType<ConflictObjectResult>().Subject;
			return Task.FromResult((string)objectResult.Value!);
		}
		public static Task<string> GetErrorMessageFromUnauthorizedResponse<T>(ActionResult<T> response)
		{
			var objectResult = response.Result.Should().BeOfType<UnauthorizedObjectResult>().Subject;
			return Task.FromResult((string)objectResult.Value!);
		}
		public static Task<string> GetErrorMessageFromNotFoundResponse<T>(ActionResult<T> response)
		{
			var objectResult = response.Result.Should().BeOfType<NotFoundObjectResult>().Subject;
			return Task.FromResult((string)objectResult.Value!);
		}
	}
}
