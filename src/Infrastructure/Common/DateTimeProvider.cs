using Application.Common.Interfaces;

namespace Infrastructure.Common;

public class DateTimeProvider : IDateTime
{
	public DateTime Now => DateTime.Now;
}