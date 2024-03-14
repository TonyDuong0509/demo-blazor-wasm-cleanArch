using ApplicationLayer.Commands.EmployeeCommand;
using ApplicationLayer.DTOs;
using InfrastructureLayer.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Handlers.EmployeeHandler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ServiceResponse>
    {
        private readonly AppDbContext _appDbContext;

        public CreateEmployeeHandler(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<ServiceResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var check = await _appDbContext.Employees
                .FirstOrDefaultAsync(_ => _.Name.ToLower() == request.employee.Name.ToLower());

            if (check != null)
            {
                return new ServiceResponse(false, "User already exsist");
            }

            _appDbContext.Employees.Add(request.employee);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return new ServiceResponse(true, "Added");
        }
    }
}
