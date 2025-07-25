﻿using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using SocialMedia.SharedKernel.UseCases;
using SocialMedia.Users.Application.Dtos;

namespace SocialMedia.Users.Application.UseCases.Commands;

internal sealed record RejectFollowCommand(FollowDto Data) : Command;

internal class RejectFollowCommandHandler(IUserDatabaseContext db) : CommandHandler<RejectFollowCommand>(db)
{
	public override async Task<Result> Handle(RejectFollowCommand req, CancellationToken ct)
	{
		var data = req.Data;

		var follow = await db.Follows
			.Where(_ => _.FollowerId == data.FollowerId)
			.Where(_ => _.FollowingId == data.FollowingId)
			.FirstOrDefaultAsync(ct);

		if (follow is null)
			return Result.NotFound("Follow request not found.");

		db.Follows.Remove(follow);
		await db.SaveChangesAsync(false, ct);

		return Result.NoContent();
	}
}