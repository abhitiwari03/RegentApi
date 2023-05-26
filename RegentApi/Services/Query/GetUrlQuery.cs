using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RegentApi.DTO;
using RegentApi.Models;

namespace RegentApi.Services.Query
{
    public class GetUrlQuery : IRequest<bool>
    {
        public int Id { get; set; }
        public JobProfileVM? Model { get; set; }
    }
    public class GetUsersHandler : IRequestHandler<GetUrlQuery, bool>
    {
        private readonly RegentDB_NewContext m_context;
        private readonly IMapper m_mapper;
        public GetUsersHandler(RegentDB_NewContext context, IMapper mapper)
        {
            m_context = context;
            m_mapper = mapper;
        }
        public async Task<bool> Handle(GetUrlQuery request, CancellationToken cancellationToken)
        {
            bool isavailable = false;
            if (request.Id< 1)
            {
                var profiles = await m_context.JobProfiles.Where(x => x.Url == request.Model.Url).ToListAsync();
                isavailable = profiles.Count() > 0 ? true : false; 
            }
            else
            {
               var profileurl= await m_context.JobProfiles.Where(x => x.Url == request.Model.Url && x.Url != request.Model.Url).ToListAsync();
                isavailable=profileurl.Count() > 0 ? true : false;
            }

            return isavailable;
        }
    }
}
