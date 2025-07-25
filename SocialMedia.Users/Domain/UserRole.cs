﻿using SocialMedia.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Users.Domain;

internal class UserRole
{
	public Guid UserId { get; set; }

	public eSystemRole RoleId { get; set; }

	[ForeignKey(nameof(UserId))]
	public virtual User User { get; set; }
}