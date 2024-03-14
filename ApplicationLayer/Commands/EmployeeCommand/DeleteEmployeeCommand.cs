using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands.EmployeeCommand
{
    public class DeleteEmployeeCommand : IRequest<ServiceResponse>
    {
        public int Id { get; set; }
    }
}
