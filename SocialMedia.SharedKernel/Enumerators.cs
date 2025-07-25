﻿using System.ComponentModel;

namespace SocialMedia.SharedKernel;

public enum eSystemRole
{
	[Description("")]
	NotSet = 0,

	[Description("System Administrator")]
	SystemAdministrator = 1,

	[Description("Member")]
	Member = 2,
}

public enum eNotificationType
{
	[Description("")]
	NotSet = 0,

	[Description("Follow Request")]
	FollowRequest = 10,

	[Description("Follow Accepted")]
	FollowAccepted = 20,

	[Description("Started Following")]
	StartedFollowing = 30,
}

public enum eNotificationActionMethodType
{
	[Description("")]
	NotSet = 0,

	[Description("GET")]
	Get = 100,

	[Description("POST")]
	Post = 200
}