using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Controllers
{
    [RoutePrefix("api/v1/members")]
    public class MembersController : ApiController
    {

        private readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        //public IHttpActionResult GetAll()
        //{
        //    try
        //    {
        //        var member = _membersService.GetAllMembers();
        //        return Ok(member);
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex);
        //        return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
        //    }
        //}


        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetMemberById(int id)
        {
            try
            {
                var member = _membersService.GetMemberById(id);
                return Ok(member);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetMemberByEmail(string email)
        {
            try
            {
                var member = _membersService.GetMemberByEmail(email);
                return Ok(member);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }
        [HttpGet]
        [Route("{username:alpha}")]
        public IHttpActionResult GetMemberByUsername(string username)
        {
            try
            {
                var member = _membersService.GetMemberByUsername(username);
                return Ok(member);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }
    }
}