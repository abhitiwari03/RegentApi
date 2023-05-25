using MediatR;
using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Application.Mapping;
using RegentApi.DTO;
using RegentApi.Models;
using System.Threading;

namespace RegentApi.Services.Command
{
    public class AddNewJobProfileCommand : IRequest<JobProfileVM>
    {
        public JobProfileVM? Model { get; set; }
    }

    public class UpdateRoleHandler : IRequestHandler<AddNewJobProfileCommand, JobProfileVM>
    {
        private readonly RegentDB_NewContext m_context;
        private readonly IMapper m_mapper;
        public UpdateRoleHandler(RegentDB_NewContext context, IMapper mapper)
        {
            m_context = context;
            m_mapper = mapper;
        }

        public async Task<JobProfileVM> Handle(AddNewJobProfileCommand request, CancellationToken cancellation)
        {
            //var entity = await m_context.JobProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Model.Id, cancellation);
            var jobProfile = await m_context.JobProfiles.AsNoTracking().ToArrayAsync();
            var newProfile = m_mapper.Map < JobProfile[],JobProfile[]>(jobProfile);
            m_context.Add(newProfile);
            await m_context.SaveChangesAsync();
            return m_mapper.Map< JobProfile[],JobProfileVM >(newProfile);
        }

    }
}
