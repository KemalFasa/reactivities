using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
    //     private readonly IMediator _mediator;
    //     public ActivitiesController(IMediator mediator)
    //     {
    //         _mediator = mediator;
    //     }

    //     [HttpGet]
    //     public async Task<ActionResult<List<Activity>>> GetActivities(){
    //         return await _mediator.Send(new List.Query());    
    //     }
        
    //     [HttpGet("{id}")]
    //     public async Task<ActionResult<Activity>> GetActivity(Guid id){
    //         return Ok();    
    //     }
    [HttpGet]
        public async Task<IActionResult> GetActivities(){
            return HandleResult(await Mediator.Send(new List.Query()));    
        }
        
    [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(Guid id){
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
        }
    [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity){
            return HandleResult(await Mediator.Send(new Create.Command {Activity = activity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity){
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command {Activity = activity}));
        }
      [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id){
            return HandleResult(await Mediator.Send(new Delete.Command {Id = id}));
        }
    }
    

}