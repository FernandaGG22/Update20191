using SalesWebMVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC1.Services.Exceptions;

namespace SalesWebMVC1.Services
{
    public class SellerService
    {

        private readonly SalesWebMVC1Context _context;

        public SellerService(SalesWebMVC1Context context)
        {
            _context = context;
        }

        //sincrono
        /*        public List<Seller> FindAll()
                {
                    return _context.Seller.ToList();
                } 
                */

        //assincrono
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        //sincrono
 /*       public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
*/
        //assincrono
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChangesAsync();
        }

        //sincrono
        /*        public Seller FindById(int id)
                {
                    return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
                }*/

        //assincrono
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        //sincrono
/*        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
*/
        //assincrono
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        //sincrono
        /*        public void Update(Seller obj)
                {
                    if(!_context.Seller.Any(x => x.Id == obj.Id))
                    {
                        throw new NotFoundException("Id not found");
                    }
                    try
                    {
                        _context.Update(obj);
                        _context.SaveChanges();
                    }
                    catch(DbUpdateConcurrencyException e)
                    {
                        throw new DbConcurrencyException(e.Message);
                    }
                }
        */
        //assincrono
        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (! hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
