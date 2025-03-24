using GymManagerApp.Domain.Common;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities;
public class Person : BaseEntity
{
    public string Name { get; protected set; }
    public string LastName { get; protected set; }
    public Gender Gender { get; protected set; }
    public string PhoneNumber { get; protected set; }
}