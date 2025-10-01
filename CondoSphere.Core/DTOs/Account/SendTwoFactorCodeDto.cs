using CondoSphere.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Send Two Factor Code DTO.
    /// </summary>
    public class SendTwoFactorCodeDto
    {
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public TwoFactorMethod Method { get; set; }
    }
}
