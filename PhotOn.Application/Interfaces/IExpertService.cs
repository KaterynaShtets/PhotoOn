using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Interfaces
{
    public interface IExpertService
    {
        void ApprovePublication(int publicationId);
        void RejectPublication(int publicationId);
    }
}
