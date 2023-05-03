﻿using Application.Parameters;

namespace Application.Features.LeaveRequest.Queries.GetAllLeaveRequestQuery;

public class GetAllLeaveRequestParameters : RequestParameter
{
    public string? LeaveReasonComments { get; set; }
    public Guid? ResourceId { get; set; }
    public bool State { get; set; }
}