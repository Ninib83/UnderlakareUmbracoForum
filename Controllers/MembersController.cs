﻿using System;
using System.Net;
using System.Web.Http;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.ViewModel;
using UmderlakareUmbCms.Business.Registries;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Controllers
{
    [IncludeInApiExplorer]
    [RoutePrefix("api/v1/members")]
    public class MembersController : ApiController
    {

        private readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        #region HttpGet


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

                [HttpGet]
        [Route("member/isLoggedIn")]
        public IHttpActionResult IsLoggedIn()
        {
            try
            {
  
               bool status = _membersService.IsLoggedIn();


                return Content(HttpStatusCode.OK, status);
            }
            catch (Exception)
            {


                return Content(HttpStatusCode.InternalServerError, "something went wrong");
            }


        }

        #endregion

        #region HttpPost

        [HttpPost]
        [Route("member/login")]
        public IHttpActionResult LoginMember(LoginMemberViewModel vm)
        {
            try
            {

                _membersService.Login(vm);


                return Ok();
            }
            catch (Exception)
            {


                return Content(HttpStatusCode.InternalServerError, "something went wrong when login");
            }


        }



        [HttpPost]
        [Route("member/logout")]
        public IHttpActionResult LogOff()
        {


            try
            {

                _membersService.LogOff();

                return Ok();
            }
            catch (Exception)
            {


                return Content(HttpStatusCode.InternalServerError, "something went wrong when logout");
            }


        }


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

                return Content(HttpStatusCode.InternalServerError, "something went wrong");
            }
        }

        [HttpPost]
        [Route("member/resetPasword")]
        public IHttpActionResult ResetPassword(Dialogue.Logic.Models.Member member, string newPassword)
        {
            try
            {
                _membersService.ResetPassword(member, newPassword);
                return Ok();
            }
            catch (Exception)
            {

                return Content(HttpStatusCode.InternalServerError, "something went wrong");
            }
        }


        #endregion


    }
}