using GymManagerApp.Application.Common.Interfaces;

namespace GymManagerApp.Infrastructure;

public class DateTimeProvider : IDateTime
{
	public DateTime Now => DateTime.Now;
}
