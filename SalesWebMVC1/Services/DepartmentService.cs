using SalesWebMVC1.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC1.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVC1Context _context;

        public DepartmentService(SalesWebMVC1Context context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
