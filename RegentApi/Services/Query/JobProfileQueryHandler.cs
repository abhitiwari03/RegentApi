using MediatR;
using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Application.Mapping;
using RegentApi.DTO;
using RegentApi.Models;

namespace RegentApi.Services.Query
{
    public class JobProfileQuery : IRequest<JobProfileVM[]>
    {
        public long UserId { get; set; }
        public long CommentId { get; set; }
        public JobProfileVM? Model { get; set; }
    }
    public class JobProfileHandler: IRequestHandler<JobProfileQuery, JobProfileVM[]>
    {
        private readonly RegentDB_NewContext m_context;
        private readonly IMapper m_mapper;

        public JobProfileHandler(RegentDB_NewContext context, IMapper mapper)
        {
            m_context = context;
            m_mapper = mapper;
        }
        public async Task<JobProfileVM[]> Handle(JobProfileQuery request, CancellationToken cancellationToken)
        {
            var users = await m_context.Users.AsNoTracking().Where(x => x.Id == request.UserId.ToString()).ToArrayAsync();
            var roles = await m_context.Roles.AsNoTracking().ToArrayAsync();
            var jobProfile = await m_context.JobProfiles.AsNoTracking().ToArrayAsync();
            var result = m_mapper.Map<JobProfile[], JobProfileVM[]>(jobProfile);
            for (int i = 0; i < result.Count(); i++)
            {
                var role = roles.FirstOrDefault(x => x.Users == result[i]);
                if (role != null)
                    result[i].RoleName = Enum.GetName(typeof(JobProfile), role.Id);
            }
            return result;


        }

         

    }
}
