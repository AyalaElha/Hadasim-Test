using Covid.Core.Entities;
using Covid.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Data.Repositories
{
    public class MemberRepository:IMemberRepository
    {
        private readonly DataContext _context;
        public MemberRepository(DataContext context)
        {
            _context = context;
        }

        public Member AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
            return member;
        }

        public void DeleteMember(int id)
        {
            _context.Members.Remove(GetMemberById(id));
            _context.SaveChanges();
        }

        public Member GetMemberById(int id)
        {
            return _context.Members.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Member> GetMembers()
        {
            return _context.Members.Include(x=>x.CovidDetails);
        }

        public Member UpdateMember(int id, Member member)
        {
            var updateMember=GetMemberById(id);
            if(updateMember!=null)
            {
                updateMember.IdentityNum= member.IdentityNum;
                updateMember.Fname= member.Fname ;  
                updateMember.Lname= member.Lname ;
                updateMember.City = member.City;
                updateMember.Street= member.Street ;    
                updateMember.NumAdress= member.NumAdress ;  
                updateMember.BirthDay= member.BirthDay ;    
                updateMember.Phone = member.Phone ;  
                updateMember.MobilePhone = member.MobilePhone ;
                _context.SaveChanges();
            }

            return updateMember; 

        }
    }
}
