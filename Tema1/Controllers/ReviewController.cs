using Project.Core.Services;
using Project.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Project.Database.Dtos.Request;
using Project.Database.Dtos.Response;

namespace LabProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet("produs/{produsId}/reviews")]
        public IActionResult GetReviewsByProdusId([FromRoute] int produsId)
        {
            var reviews = _reviewService.GetReviewsByProdusId(produsId);
            return Ok(reviews);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddReview([FromBody] AddReviewRequest addReviewRequest)
        {
            _reviewService.AddReview(addReviewRequest);
            return Ok("Review has been successfully created");
        }

        [HttpPut]
        [Route("{reviewId}/edit-review")]
        public IActionResult UpdateReview([FromRoute]int reviewId,[FromBody] UpdateReviewRequest updateReviewRequest)
        {
            if (reviewId != updateReviewRequest.Id)
            {
                return BadRequest();
            }

            _reviewService.UpdateReview(reviewId,updateReviewRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("delete-review")]
        public IActionResult DeleteReview([FromQuery] int reviewId)
        {
            var deleteReviewRequest = new DeleteReviewRequest { Id = reviewId };
            _reviewService.DeleteReview(deleteReviewRequest);
            return Ok("Review has been successfully deleted");
        }
    }
}
