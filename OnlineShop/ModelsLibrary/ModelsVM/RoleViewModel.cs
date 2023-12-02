﻿
using System.ComponentModel.DataAnnotations;

namespace ModelsLibrary.ModelsVM
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Не указано название роли")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 символов и не более 50 символов")]
        public string Name { get; set; }
        public RoleViewModel(string name)
        {
            Name = name;
        }
        public RoleViewModel()
        {
        }
    }
}
