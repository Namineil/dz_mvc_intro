using BLL.DTO;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
	{
            IRepository<Category> categoryRepo;
            public CategoryService(IRepository<Category> categoryRepo)
            {
                this.categoryRepo = categoryRepo;
            }

            public CategoryDTO CreateOrUpdate(CategoryDTO dto)
            {
                Category newCategory = new Category
                {
                    CategoryId = dto.CategoryId,
                    CategoryName = dto.CategoryName
                };
                categoryRepo.CreateOrUpdate(newCategory);
                return new CategoryDTO
                {
                    CategoryId = newCategory.CategoryId,
                    CategoryName = newCategory.CategoryName
                };
            }

            public CategoryDTO Get(int id)
            {
                var category = categoryRepo.Get(id);
                return new CategoryDTO
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
            }

            public IEnumerable<CategoryDTO> ListAll()
            {
                return categoryRepo
                        .GetAll()
                            .Select(x => new CategoryDTO
                            {
                                CategoryId = x.CategoryId,
                                CategoryName = x.CategoryName
                            });
            }

            public CategoryDTO Remove(CategoryDTO dto)
            {
                Category category = new Category
                {
                    CategoryId = dto.CategoryId,
                    CategoryName = dto.CategoryName
                };
                categoryRepo.Delete(category);
                return dto;
            }

            public void Save()
            {
                categoryRepo.Save();
            }
        }
}
