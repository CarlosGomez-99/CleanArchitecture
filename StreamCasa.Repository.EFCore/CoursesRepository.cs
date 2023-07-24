using Microsoft.EntityFrameworkCore;
using StreamCasa.Entities;
using StreamCasa.Entities.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamCasa.Repository.EFCore
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly StreamCasaDBContext _dbContext;

        public CoursesRepository(StreamCasaDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Courses> Add(Courses courses)
        {
            if (courses.Id != Guid.Empty)
            {
                _dbContext.Courses.Update(courses);
            }
            else
            {
                await _dbContext.Courses.AddAsync(courses);
            }
            await _dbContext.SaveChangesAsync();
            return courses;
        }

        public async Task<Courses> Delete(Courses courses)
        {
            _dbContext.Courses.Remove(courses);
            await _dbContext.SaveChangesAsync();
            return courses;
        }
    }
}
