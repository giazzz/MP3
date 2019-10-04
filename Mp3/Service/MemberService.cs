using Mp3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3.Service
{
    interface MemberService
    {
        String Login(String username, String password, String loginUrl);
        Member Register(Member member, String registerUrl);
        Member GetInformation(String token, String infoUrl);
    }
}
