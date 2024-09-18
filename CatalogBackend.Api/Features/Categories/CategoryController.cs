using CatalogBackend.Api.Features.Categories.Commands.CreateCategory;
using CatalogBackend.Api.Features.Categories.Queries.GetAllCategories;
using CatalogBackend.Api.Features.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogBackend.Api.Features.Categories
{
    [Route("api/[controller]")]
  [ApiController]
  public class CategoryController(IMediator mediator) : ControllerBase
  {
    private readonly IMediator _mediator = mediator;

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<CategoryDto>>> GetCategory(Guid id, CancellationToken cancellationToken)
    {
      var query = new GetCategoryQuery() { Id = id };
      var category = await _mediator.Send(query, cancellationToken);

      var response = new ApiResponse<CategoryDto>();

      if (category == null)
      {
        response.Status = new Status { Code = StatusCodes.Status404NotFound, Message = $"Category with Id {id} not found." };
        response.Errors.Add(new Error { Code = "CATEGORY_NOT_FOUND", Message = "Category not found", Field = "id" });
        return NotFound(response);
      }

      response.Status = new Status { Code = StatusCodes.Status200OK, Message = "Category found." };
      response.Data = category;
      return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<CategoryDto>>>> GetAllCategories(CancellationToken cancellationToken)
    {
      var query = new GetAllCategoriesQuery();
      var categories = await _mediator.Send(query, cancellationToken) as IEnumerable<CategoryDto>;
      var response = new ApiResponse<IEnumerable<CategoryDto>>();

      if (categories == null || !categories.Any())
      {
        response.Status = new Status { Code = StatusCodes.Status404NotFound, Message = $"Categories not found." };
        response.Errors.Add(new Error { Code = "CATEGORIES_NOT_FOUND", Message = "Categories not found" });

        return NotFound(response);                 
      }

      response.Status = new Status { Code = StatusCodes.Status200OK, Message = "Categories found." };
      response.Data = categories;

      return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CategoryDto>>> CreateCategory([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
      var response = new ApiResponse<CategoryDto>();

      if (!ModelState.IsValid)
      {
        response.Status = new Status
        {
          Code = StatusCodes.Status422UnprocessableEntity,
          Message = "Unprocessable Entity."
        };

        foreach (var modelState in ModelState)
        {
          foreach (var error in modelState.Value.Errors)
          {
            response.Errors.Add(new Error
            {
              Code = "VALIDATION_ERROR",
              Message = error.ErrorMessage,
              Field = modelState.Key
            });
          }
        }

        return UnprocessableEntity(response);
      }

      var result = (CategoryDto)await _mediator.Send(command, cancellationToken);

      if (result is null)
      {
        response.Status = new Status { Code = StatusCodes.Status400BadRequest, Message = "Category not created." };
        response.Errors.Add(new Error { Code = "CATEGORY_NOT_CREATED", Message = "Category not created." });

        return BadRequest(response);
      }

      response.Status = new Status { Code = StatusCodes.Status201Created, Message = "Category created." };
      response.Data = result;

      return CreatedAtAction(nameof(GetCategory), new { id = result.Id }, response);
    }
  }
}
