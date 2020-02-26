using SalesWebMVC1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SalesWebMVC1.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVC1Context _context;

        public DepartmentService(SalesWebMVC1Context context)
        {
            _context = context;
        }

        //sincrona 
        /*        public List<Department> FindAll()
                {
                    return _context.Department.OrderBy(x => x.Name).ToList();
                }
          */
        //assincrona
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
