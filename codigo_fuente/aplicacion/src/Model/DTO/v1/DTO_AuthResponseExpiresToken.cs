using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.v1;

public class DTO_AuthResponseExpiresToken
{
    public bool IsAuthSuccessful { get; set; }

    public string ErrorMessage { get; set; }

    public string Token { get; set; }

    public string RefreshToken { get; set; }
    public string AccessTokenExpires { get; set; }
}