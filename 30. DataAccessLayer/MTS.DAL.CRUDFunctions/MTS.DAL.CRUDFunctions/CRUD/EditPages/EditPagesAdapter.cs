using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using MTS.DAL.DatabaseAccess.DataContext;
using MTS.DAL.Entities.Core.EditPageContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.CRUD.EditPages
{
    public sealed class EditPagesAdapter : IEditPageAdapter
    {
        private readonly ApplicationDbContext _dbContext;

        public EditPagesAdapter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Create
        #endregion

        #region Read
        public async Task<ICollection<IBLPageSection>> ReadByPageRouteAsync(string pageRoute)
        {
            if (String.IsNullOrEmpty(pageRoute))
                throw new ArgumentException("Parameters pageRoute cannot be null or empty");

            var result = _dbContext.PageSections.Where(ps => ps.PageRoute == pageRoute).Include(sp => sp.DALSectionParts);

            return await result.ToArrayAsync();
        }

        public async Task<IBLPageSection> ReadByIdAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("Parameters id cannot be null or empty");

            var guid = new Guid(id);
            DALPageSection dalPageSection = await _dbContext.PageSections.FirstOrDefaultAsync(ps => ps.PageSectionId == guid);

            if (dalPageSection == null)
            {
                throw new Exception("No UserAccount was found matching this id");

            }

            return dalPageSection;
        }
        #endregion

        #region Write
        #endregion

        #region Delete
        #endregion
    }
}
