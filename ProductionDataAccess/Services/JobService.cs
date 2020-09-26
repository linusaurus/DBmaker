using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionDataAccess.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using DBmaker.Data;
    using DBmaker.Models;
    
    using Microsoft.EntityFrameworkCore;
    using ProductionDataAccess.Mappers;

    namespace DataAccess.Service
    {
        public class JobService
        {
            private readonly ProductionContext ctx;
            private JobMapper jobMapper = new JobMapper();

            public List<Job> Jobs;

            public JobService()
            {
                ctx = new ProductionContext();
            }
            /// <summary>
            /// Return Job Dto
            /// </summary>
            /// <param name="JobId"></param>
            /// <returns></returns>
            public JobListDto FindJobDto(int JobId)
            {
                Job job = ctx.Job.Find(JobId);
                JobListDto dto = new JobListDto();
                jobMapper.Map(job, dto);
                return dto;

            }

            public Job GetDeepJob(int jobID)
            {
                return ctx.Job.Include(s => s.Product)
                    .ThenInclude(s => s.SubAssembly)
                    .Where(j => j.JobID == jobID).FirstOrDefault();
            }

            public Job FindJob(int jobID)
            {

                return ctx.Job.Find(jobID);
            }
            /// <summary>
            /// Return list of 25 most recent Jobs
            /// </summary>
            /// <returns></returns>
            public List<JobListDto> RecentJobs()
            {
                var jobs = ctx.Job.AsNoTracking().OrderByDescending(r => r.start_ts).Select(d => new JobListDto
                {
                    JobID = d.JobID,
                    JobName = d.JobName
                }).Take(35).ToList();
                return jobs;
            }

            public List<Job> SearchJobs(string term)
            {

                return ctx.Job.Where(w => w.JobName.Contains(term)).ToList();
            }



        }
    }

}
