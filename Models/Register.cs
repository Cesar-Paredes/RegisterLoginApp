using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegisterLoginAppn.Models;

public partial class Register
{
    public int RegisterId { get; set; }

    [Required(ErrorMessage ="Username is required")]
    [RegularExpression("[A-Za-z]*", ErrorMessage = "Username must contain characters only")]
    public string Username { get; set; } = null!;
    [Required(ErrorMessage = "Loginname is required")]
    [RegularExpression("[A-Za-z0-9]*", ErrorMessage = "Login name must contain characters and numbers only")]
    public string Loginname { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage ="Invalid Email")]
    public string Email { get; set; } = null!;   

    
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Minimum length of the password must be 6 characters")]
    [MaxLength(15, ErrorMessage = "Maximum length of the password must be 15 characters")]
    public string Password { get; set; } = null!;
}
