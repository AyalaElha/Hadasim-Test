using Covid.Core.Entities;
using Covid.Core.Repositories;
using Covid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository=memberRepository;
        }
        public Member AddMember(Member member)
        {
            if(Validation.CheckMember(member))  
                   return _memberRepository.AddMember(member);
            return member;
        }

        public IEnumerable<Member> GetMembers()
        {
            return _memberRepository.GetMembers();
        }

        public Member GetMemberById(int id)
        {
            return _memberRepository.GetMemberById(id);   
        }

        public Member UpdateMember(int id, Member member)
        {
            return _memberRepository.UpdateMember(id, member);    
        }

        public void DeleteMember(int id)
        {
            _memberRepository.DeleteMember(id);
        }
    }
}
