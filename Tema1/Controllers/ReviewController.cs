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

        [HttpGet("produs/{produsId}")]
        public ActionResult<IEnumerable<GetReviewResponse>> GetReviewsByProdusId(int produsId)
        {
            var reviews = _reviewService.GetReviewsByProdusId(produsId);
            return Ok(reviews);
        }

        [HttpPost]
        public ActionResult AddReview(AddReviewRequest addReviewRequest)
        {
            _reviewService.AddReview(addReviewRequest);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateReview(int id, UpdateReviewRequest updateReviewRequest)
        {
            if (id != updateReviewRequest.Id)
            {
                return BadRequest();
            }

            _reviewService.UpdateReview(updateReviewRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReview(int id)
        {
            var deleteReviewRequest = new DeleteReviewRequest { Id = id };
            _reviewService.DeleteReview(deleteReviewRequest);
            return Ok();
        }
    }
}
