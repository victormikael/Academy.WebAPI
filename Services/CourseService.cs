using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services
{
    public class CourseService : ICourseService
    {
        
        private readonly CourseDbContext _context;
        public CourseService(CourseDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> Create(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return true;
        }
        public Course GetById(int id)
        {
            var getById = _context.Courses.Find(id);

            return getById;
        }

        public IEnumerable<Course> GetByName(string name)
        {
            var getByName = _context.Courses.Where(x => x.Name.Contains(name)).ToList();
            
            return getByName;
        }

        public async Task<bool> Update(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> Delete(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}