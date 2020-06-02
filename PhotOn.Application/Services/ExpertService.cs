using Microsoft.Extensions.Logging;
using PhotOn.Application.Interfaces;
using PhotOn.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Services
{
    public class ExpertService : IExpertService
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<EventService> _logger;

        public ExpertService(IUnitOfWork unitOfWork, ILogger<EventService> logger)
        {
            _db = unitOfWork;
            _logger = logger;
        }

        public void ApprovePublication(int publicationId)
        {
            _db.Publications.ApprovePublication(publicationId);
            _db.Save();
        }

        public void RejectPublication(int publicationId)
        {
            _db.Publications.RejectPublication(publicationId);
            _db.Save();
        }

        public void GetAllPublicationForApprovement()
        {
            _db.Publications.GetAllPresentDisApproved();
        }
    }
}
