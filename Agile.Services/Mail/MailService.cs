using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Agile.Data;
using Agile.Data.Entities;
using Agile.Models.Mail;

namespace Agile.Services.Mail
{
        public class MailService : IMailService
    {
        private readonly ApplicationDbContext _context;
        private int _userId;
        private ApplicationDbContext DbContext;

        public MailService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build Mail Service without User Id claim.");

            DbContext = context;
        }

        
        public async Task<bool> CreateMailAsync(MailCreate request)
        {
            var mailEntity = new MailEntity
            {
            Subject = request.Subject,
            Body = request.Body,
            SenderId = request.SenderId,
            ReceiverId = request.ReceiverId,
            BoxId = request.BoxId,
            };

            DbContext.Reply.Add(mailEntity);

            var numberOfChanges = await DbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public Task<bool> DeleteMailAsync(int mailId)
        {
            throw new NotImplementedException();
        }

        public Task<MailDetail> GetMailByIdAsync(int mailId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMailAsync(MailUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}