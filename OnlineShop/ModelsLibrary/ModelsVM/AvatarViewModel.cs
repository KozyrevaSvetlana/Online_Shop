using Microsoft.AspNetCore.Http;
using System;

namespace ModelsLibrary.ModelsVM
{
    public class AvatarViewModel
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; }

    }
}
