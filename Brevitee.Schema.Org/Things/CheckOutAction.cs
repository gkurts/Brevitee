using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of an agent communicating (service provider, social media, etc) their departure of a previously reserved service (e.g. flight check in) or place (e.g. hotel).Related actions:CheckInAction: The antagonym of CheckOutAction.DepartAction: Unlike DepartAction, CheckOutAction implies that the agent is informing/confirming the end of a previously reserved service.CancelAction: Unlike CancelAction, CheckOutAction implies that the agent is informing/confirming the end of a previously reserved service.</summary>
	public class CheckOutAction: CommunicateAction
	{
	}
}
