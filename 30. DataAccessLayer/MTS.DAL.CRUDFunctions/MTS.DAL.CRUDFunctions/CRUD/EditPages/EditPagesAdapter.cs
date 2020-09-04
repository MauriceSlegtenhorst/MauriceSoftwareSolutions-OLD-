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

            var result = _dbContext.PageSections.Where(ps => ps.PageRoute == pageRoute).Include(sp => sp.DALSectionParts).AsNoTracking();

            ICollection<IBLPageSection> blPageSections = await result.ToArrayAsync();

            return blPageSections;
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

        #region Update
        public async Task UpdateByPageSectionsAsync(ICollection<IBLPageSection> blPageSections)
        {
            if (blPageSections == null)
                throw new ArgumentNullException($"{nameof(blPageSections)} was null");

            foreach (IBLPageSection blPageSection in blPageSections)
            {
                //DALPageSection pageFromDB = _dbContext.PageSections.First(ps => ps.PageSectionId == blPageSection.PageSectionId);

                //pageFromDB.Parts = blPageSection.Parts;

                foreach (IBLSectionPart blPart in blPageSection.Parts)
                {
                    _dbContext.Update(blPart);
                }

                _dbContext.Update((DALPageSection)blPageSection);
            }

            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Delete
        #endregion
    }
}
