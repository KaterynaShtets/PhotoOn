using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Application.Interfaces
{
    public interface IFileStorageServcie
    {
        string EditFile(byte[] content, string extension, string containerName, string fileRoute, string contentType);
        void DelteFile(string fileRoute, string containerName);
        string SaveFile(byte[] content, string extension, string containerName, string contentType);
    }
}
