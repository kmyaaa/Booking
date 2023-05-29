using Booking.Application.Reservations.Commands;
using Booking.Application.Reservations.Queries;
using Booking.Application.Reservations.Validators;
using Booking.Common.Exceptions;
using Booking.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/reservations")]
public class ReservationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Insert a new reservation in the DB.
    /// </summary>
    /// <response code="200">Return the inserted model for the reservation.</response>
    /// <response code="500">Unable to insert reservation due to a server error</response>
    /// <response code="400">Unable to insert reservation due to a client error</response>
    [HttpPost]
    public async Task<ActionResult<Reservation>> CreateReservation([FromBody] CreateReservationCommand command)
    {
        var validator = new CreateReservationCommandValidator();
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var reservationId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetReservation), new { id = reservationId }, reservationId);
    }

    /// <summary>
    /// Update an exist reservation in the DB.
    /// </summary>
    /// <response code="200">Return reservation model.</response>
    /// <response code="500">Unable to insert reservation due to a server error</response>
    /// <response code="400">Unable to insert reservation due to a client error</response>
    /// <response code="404">The Id doesn't match any record in the DB</response>
    [HttpPut]
    public async Task<ActionResult<Reservation>> UpdateReservation(int id, [FromBody] UpdateReservationCommand command)
    {
        if (id != command.ReservationId)
        {
            return BadRequest("The ID provided in the URL does not match the ID in the request body.");
        }

        try
        {

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Delete reservation by Id.
    /// </summary>
    /// <param name="id">Represent the unique id of the reservation</param>
    /// <response code="500">Unable to delete reservation due to a server error</response>
    /// <response code="404">The Id doesn't match any record in the DB</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        try
        {
            await _mediator.Send(new DeleteReservationCommand { ReservationId = id });
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

    }
    /// <summary>
    /// Get reservation by Id.
    /// </summary>
    /// <param name="id">Represent the unique id of the reservation </param>
    /// <response code="200">Return the desired reservation by Id.</response>
    /// <response code="500">Unable to return reservation due to a server error</response>
    /// <response code="404">The Id doesn't match any record in the DB</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Reservation>> GetReservation(int id)
    {
        var reservation = await _mediator.Send(new GetReservationByIdQuery { ReservationId = id });

        if (reservation == null)
        {
            return NotFound();
        }

        return Ok(reservation);
    }


    [HttpGet("users/{userId}")]
    public async Task<IEnumerable<Reservation>> GetReservationsByUserId(int userId)
    {
        return await _mediator.Send(new GetReservationsByUserIdQuery { UserId = userId });
    }

    [HttpGet("trips/{tripId}")]
    public async Task<IEnumerable<Reservation>> GetReservationsByTripId(int tripId)
    {
        return await _mediator.Send(new GetReservationsByTripIdQuery { TripId = tripId });
    }
}
