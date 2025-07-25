﻿using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using SocialMedia.SharedKernel.UseCases;
using SocialMedia.Users.Application.Dtos;

namespace SocialMedia.Users.Application.UseCases.Commands;

internal sealed record UnfollowCommand(FollowDto Data) : Command;

internal class UnfollowCommandHandler(IUserDatabaseContext db) : CommandHandler<UnfollowCommand>(db)
{
	public override async Task<Result> Handle(UnfollowCommand req, CancellationToken ct)
	{
		var data = req.Data;

		var follow = await db.Follows
			.Where(_ => _.FollowerId == data.FollowerId)
			.Where(_ => _.FollowingId == data.FollowingId)
			.FirstOrDefaultAsync(ct);

		if (follow is null)
			return Result.NotFound("Follow doesn't exist.");

		db.Follows.Remove(follow);
		await db.SaveChangesAsync(false, ct);

		return Result.NoContent();
	}
}