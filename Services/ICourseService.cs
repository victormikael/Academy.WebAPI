using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ICourseService
    {        
        Task<bool> Create(Course course);
        Course GetById(int id);
        IEnumerable<Course> GetByName(string name);
        Task<bool> Update(Course course);
        Task<bool> Delete(Course course);
        
    }
}