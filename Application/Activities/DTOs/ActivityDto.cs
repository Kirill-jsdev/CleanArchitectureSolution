using Application.Users.DTOs;
using Domain;

namespace Application.Activities.DTOs;

public class ActivityDto
{
    public required string ActivityId { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }

    // location props
    public required string City { get; set; }
    public required string Place { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public required string CreatedByUserId { get; set; }

    public UserSummaryDto? CreatedBy { get; set; }

}
