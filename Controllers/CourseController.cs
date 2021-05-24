using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _service;
        public CourseController(ICourseService service)
        {
            _service = service;
        }
        
        // Post: api/course/
        /// <summary>
        /// Create a new course.
        /// </summary>
        /// <param name="course">course data to create</param> 
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(Course course)
        {
            if(!ModelState.IsValid || course.Id != 0)
            {
                return BadRequest();
            }
            
            await _service.Create(course);

            return CreatedAtAction(nameof(Create), new {Id = course.Id});
        }

        // Get: api/course/{id}
        /// <summary>
        /// Get an course by id.
        /// </summary>
        /// <param name="id">course id</param>
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Course> GetById(int id)
        {
            if(!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }

            var getById = _service.GetById(id);

            if(getById == null)
            {
                return NotFound();
            }

            return Ok(getById);
        }

        
        // Get: api/course/search/{name}
        /// <summary>
        /// Get courses by name.
        /// </summary>
        /// <param name="name">course name</param>
        [HttpGet("search/{name}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Course>> GetByName(string name)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var getByName = _service.GetByName(name);

            if(!getByName.Any())
            {
                return NoContent();
            }
            
            return Ok(getByName);
        }


        // Put: api/course/{id}
        /// <summary>
        /// Update a existing course.
        /// </summary>
        /// <param name="id">course id</param> 
        /// <param name="courseRequest">course data to update</param>
        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Update([FromBody] Course courseRequest, [FromRoute] int id)
        {
            if(!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }

            if(courseRequest.Id != 0 && courseRequest.Id != id)
            {
                return BadRequest();
            }
            
            var course = _service.GetById(id);

            if(course == null)
            {
                return NotFound();
            }

            course.Name = courseRequest.Name;
            course.Active = courseRequest.Active;
            course.Price = courseRequest.Price;
            course.Duration = courseRequest.Duration;
            course.Certified = courseRequest.Certified;

            var update = await _service.Update(course);
            
            return Ok(update);
        }
        
        // Patch: api/course/{id}
        /// <summary>
        /// Partial update a existing course.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Course
        ///     {
        ///        "active": 1,
        ///        "price": 1999,
        ///        "duration": "55 hours"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Course Id.</param> 
        /// <param name="courseRequest">course data to partial update</param>
        [HttpPatch("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> UpdatePartial([FromBody] CourseRequestUpdate courseRequest, [FromRoute] int id)
        {
            if(!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            
            var course = _service.GetById(id);

            if(course == null)
            {
                return NotFound();
            }

            if(courseRequest.Name != null)
            {
                course.Name = courseRequest.Name;
            }
            if(courseRequest.Active != course.Active)
            {
                course.Active = courseRequest.Active;
            }
            if(courseRequest.Price != 0)
            {
                course.Price = courseRequest.Price;
            }
            if(courseRequest.Duration != null)
            {
                course.Duration = courseRequest.Duration;
            }
            if(courseRequest.Certified != null)
            {
                course.Certified = courseRequest.Certified;
            }

            var update = await _service.Update(course);
            
            return Ok(update);
        }

        // Delete: api/course/{id}
        /// <summary>
        /// Deletes a specific course.
        /// </summary>
        /// <param name="id">course id</param> 
        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if(!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            
            var course = _service.GetById(id);

            if(course == null)
            {
                return NotFound();
            }
            
            var delete = await _service.Delete(course);

            return Ok(delete);
        }
    }
}