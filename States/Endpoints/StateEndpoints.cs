using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using State.Core.Dtos;
using State.Core.Requests;
using State.Services;
using System.Linq;

namespace State.Endpoints
{
    public static class StateEndpoints
    {
        public static IEndpointRouteBuilder MapStateGroup(this IEndpointRouteBuilder endpoints)
        {
            return endpoints.MapGroup("States");
        }

        public static IEndpointRouteBuilder MapStateEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            IEndpointRouteBuilder stateGroup = endpoints.MapStateGroup();

            stateGroup.MapGet("", GetState);

            stateGroup.MapGet("{id:int}", GetStateID);
            stateGroup.MapPost("", CreateState);

            return endpoints;
        }

        public static Ok<IEnumerable<Core.Dtos.StateDto>> GetState(StateService service)
        {
            IEnumerable<StateDto> list = service.GetStateList();
            return TypedResults.Ok(list);
        }

        public static IResult GetStateID(StateService service, int id)
        {
            Core.Dtos.StateDto? state = service.GetStateList()
                                     .FirstOrDefault(b => b.Id == id);

            return state is null
                ? TypedResults.NotFound()
                : TypedResults.Ok(state);
        }

        private static IResult CreateState(StateService service, CreateSateRequest request)
        {
           
                StateDto dto = service.Create(request);
                return TypedResults.Ok(dto);    
        }


    }
}