using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.BusinessLogic.Dto.IncidentDtos;
using Test.BusinessLogic.Services.Interfaces;
using Test.Domain.Context;
using Test.Domain.Entities;

namespace Test.BusinessLogic.Services.Implementation
{
    public class IncidentService : IIncidentService
    {
        private readonly ITestContext _context;
        private readonly IMapper _mapper;
        public IncidentService(ITestContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateIncidentAsync(CreateIncidentDto incidentDto)
        {
            var account = _context.Accounts.SingleOrDefault(x => x.Name == incidentDto.AccountName);
            if (account == null)
            {
                throw new NullReferenceException();
            }
            var contact = _context.Contacts.AsNoTracking().SingleOrDefault(x => x.Email == incidentDto.Email);
            if (contact == null)
            {
                contact = _mapper.Map<Contact>(incidentDto);
                contact.AccountName = incidentDto.AccountName;
                await _context.Contacts.AddAsync(contact);
            }
            else
            {
                if ((contact.AccountName == null || contact.AccountName == account.Name) && account.IncidentName == null)
                {
                    contact = _mapper.Map<Contact>(incidentDto);
                    contact.AccountName = account.Name;
                    _context.Contacts.Update(contact).State = EntityState.Modified;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            Incident incident = new Incident() { Accounts = new HashSet<Account>() { account },
                                                 Description = incidentDto.Description };
            await _context.Incidents.AddAsync(incident);
            await _context.SaveChangesAsync();
        }

        public async Task<IncidentDto?> GetIncidentAsync(string name)
        {
            var incident = await _context.Incidents.Include(x => x.Accounts)
                                                   .ThenInclude(y => y.Contacts)
                                                   .SingleOrDefaultAsync(i => i.Name == name);
            var incidentDto = _mapper.Map<IncidentDto>(incident);
            return incidentDto;
        }
    }
}
