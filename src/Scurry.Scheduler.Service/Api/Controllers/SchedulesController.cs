﻿using Scurry.Scheduler.Quartz;
using Scurry.Scheduler.Queue.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Scurry.Scheduler.Service.Api.Controllers
{
    public class SchedulesController : ApiController
    {
        // GET api/Schedules/{name}
        public HttpResponseMessage Get(string name)
        {
            try
            {
                return Request.CreateResponse<Job>(HttpStatusCode.OK, SchedulerWrapper.Wrapper.GetJob(name));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/Schedules
        public HttpResponseMessage Put(Job jobContext)
        {
            try
            {
                SchedulerWrapper.Wrapper.ScheduleJob(jobContext);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/Schedules/{name}
        public HttpResponseMessage Delete(string name)
        {
            try
            {
                SchedulerWrapper.Wrapper.DeleteJob(name);
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
