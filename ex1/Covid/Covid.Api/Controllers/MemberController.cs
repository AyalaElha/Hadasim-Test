
using Microsoft.AspNetCore.Mvc;
using Covid.Core.Entities;
using Covid.Service;
using Covid.Core.Services;
using Covid.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Covid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberServices;
        public MemberController(IMemberService memberServices)
        {
            _memberServices = memberServices;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public ActionResult  Get()
        {
            return Ok(_memberServices.GetMembers());
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public ActionResult  Get(int id)
        {
            var member= _memberServices.GetMemberById(id);  
            if(member == null)  return NotFound();
            return Ok(member);
        }

        // POST api/<MemberController>
        [HttpPost]
        public ActionResult Post([FromBody] MemberModel member )
        {
            var memberToAdd=new Member {Fname=member.Fname,Lname = member.Lname,IdentityNum=member.IdentityNum, BirthDay = member.BirthDay ,Phone=member.Phone,MobilePhone=member.MobilePhone ,City=member.City,Street=member.Street,NumAdress=member.NumAdress,CovidDetailsId=member.CovidId};
            return Ok(_memberServices.AddMember(memberToAdd));
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MemberModel member)
        {

            var memberToUpdate = new Member { Fname = member.Fname, Lname = member.Lname, IdentityNum = member.IdentityNum, BirthDay = member.BirthDay, Phone = member.Phone, MobilePhone = member.MobilePhone, City = member.City, Street = member.Street, NumAdress = member.NumAdress, CovidDetailsId = member.CovidId };
            if (_memberServices.GetMemberById(id) == null)   
                return NotFound();
            return Ok(_memberServices.UpdateMember(id, memberToUpdate));
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(_memberServices.GetMemberById(id)==null)
                return NotFound();
            _memberServices.DeleteMember(id);
            return Ok();
        }
    }
}
