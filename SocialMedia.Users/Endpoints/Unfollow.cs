﻿using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using SocialMedia.Users.Application.Dtos;
using SocialMedia.Users.Application.UseCases.Commands;

namespace SocialMedia.Users.Endpoints;

[Authorize]
internal class Unfollow(IMediator mediator) : Endpoint<FollowDto>
{
	public override void Configure()
	{
		Post("users/unfollow");
	}

	public override async Task HandleAsync(FollowDto req, CancellationToken ct)
	{
		var result = await mediator.Send(new UnfollowCommand(req), ct);

		if (result.IsNoContent())
		{
			await Send.NoContentAsync(ct);
		}
		else if (result.IsNotFound())
		{
			await Send.NotFoundAsync(ct);
		}
	}
}