using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands.EmployeeCommand
{
    public class CreateEmployeeCommand : IRequest<ServiceResponse>
    {
        public Employee? employee { get; set; }
    }
}
