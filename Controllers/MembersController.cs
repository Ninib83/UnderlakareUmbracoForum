﻿using Dialogue.Logic.Data.Context;
using Dialogue.Logic.Data.UnitOfWork;
using Dialogue.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using UmderlakareUmbCms.Business.Entities.ViewModel;
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

        #region HttpGet

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
        [Route("email")]
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

        #endregion

        #region HttpPost

        [HttpPost]
        //[Authorize]
        [Route("member/login")]
        public IHttpActionResult Login(LoginMemberViewModel vm)
        {


            try
            {

                _membersService.Login(vm);


                return Ok();
            }
            catch (Exception)
            {


                return Content(HttpStatusCode.InternalServerError, "something went wrong");
            }


        }
        #endregion

        [HttpPost]
        [Route("member/register")]
        public IHttpActionResult RegisterMember(RegisterMemberViewModel vm)
        {
            try
            {
                _membersService.Register(vm);
                return Ok();
            }
            catch (Exception)
            {

                return Content(HttpStatusCode.InternalServerError, "Not found!");
            }
        }
    }
}