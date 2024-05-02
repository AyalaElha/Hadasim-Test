using Covid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Services
{
    public interface IMemberService
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberById(int id);
        Member AddMember(Member member);
        Member UpdateMember(int id, Member member);
        void DeleteMember(int id);
    }
}
