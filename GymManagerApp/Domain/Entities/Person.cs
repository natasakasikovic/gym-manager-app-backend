using GymManagerApp.Domain.Common;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities;
public class Person : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
}